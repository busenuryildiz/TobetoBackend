//using System;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using System.Data;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Storage;
//using DataAccess.Context;

//[AttributeUsage(AttributeTargets.Method)]
//public class TransactionAttribute : ActionFilterAttribute
//{

//    ILogger _logger { get; set; }

//    public TransactionAttribute(ILogger logger)
//    {
//        _logger = logger;
//    }
//    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//    {
//        var serviceProvider = context.HttpContext.RequestServices;

//        var logger = serviceProvider.GetRequiredService<ILogger<TransactionAttribute>>();
//        var transaction = serviceProvider.GetRequiredService<TobetoContext>();

//        try
//        {
//            // Transaction başlatma
//            transaction = await transaction.BeginTransactionAsync();

//            // Action işlemlerini gerçekleştirme
//            var executedContext = await next();

//            // Hata yoksa, transaction'ı onayla
//            if (executedContext.Exception == null)
//            {
//                await transaction.CommitAsync();
//            }
//        }
//        catch (Exception ex)
//        {
//            // Hata durumunda transaction'ı iptal et
//            logger.LogError($"An error occurred: {ex.Message}");
//            await transaction.RollbackAsync();
//            throw; // Hatanın yukarıya fırlatılması
//        }
//    }
//}
