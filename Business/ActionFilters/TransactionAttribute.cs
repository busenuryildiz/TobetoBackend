using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Include this for DbContext
using DataAccess.Context;
using Serilog;

[AttributeUsage(AttributeTargets.Method)]
public class TransactionAttribute : ActionFilterAttribute
{
    private readonly ILogger _logger;

    public TransactionAttribute(ILogger logger)
    {
        _logger = logger;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        var dbContext = serviceProvider.GetRequiredService<TobetoContext>(); // Get the DbContext directly

        try
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                // Action işlemlerini gerçekleştirme
                var executedContext = await next();

                // Hata yoksa, transaction'ı onayla
                if (executedContext.Exception == null)
                {
                    await transaction.CommitAsync();
                }
            } // Transaction automatically disposed here
        }
        catch (Exception ex)
        {
            // Hata durumunda transaction'ı iptal et
            _logger.Error($"An error occurred: {ex.Message}");
            await dbContext.Database.RollbackTransactionAsync(); // Rollback using DbContext
            throw; // Hatanın yukarıya fırlatılması
        }
    }
}
