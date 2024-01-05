namespace Core.Aspects.ActionFilters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;

    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public LogActionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Information($"Action {context.ActionDescriptor.DisplayName} is executing.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                _logger.Error($"Action {context.ActionDescriptor.DisplayName} threw an exception: {context.Exception}");
            }
            else
            {
                _logger.Information($"Action {context.ActionDescriptor.DisplayName} executed.");
            }
        }
    }

}
