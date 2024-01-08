using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Include this for DbContext
using DataAccess.Context;
using Serilog;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;
using Serilog.Core;

[AttributeUsage(AttributeTargets.Method)]
public class TransactionAttribute : ActionFilterAttribute
{
    private  ILogger _logger;

    public TransactionAttribute()
    {
   
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        var dbContext = serviceProvider.GetRequiredService<TobetoContext>(); // Get the DbContext directly
         _logger = serviceProvider.GetRequiredService<ILogger>(); // Get the ILogger from the IServiceProvider
        _logger.Information("TRANSACTIN LOG WORKED");

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
