using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.ActionFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using StackExchange.Redis;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class RedisCacheRemoveAttribute : ActionFilterAttribute
    {
        private readonly IDatabase _database;
        private readonly string _customKey;

        public RedisCacheRemoveAttribute(IDatabase database, string customKey = null)
        {
            _database = database;
            _customKey = customKey;

        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (resultContext.Result is ContentResult contentResult)
            {
                var key = GenerateCacheKey(context);
                await _database.KeyDeleteAsync(key);
            }
        }

        private string GenerateCacheKey(ActionExecutingContext context)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append(context.HttpContext.Request.Path);
            foreach (var (key, value) in context.ActionArguments)
            {
                keyBuilder.Append($"_{key}_{value}");
            }

            // Use the specified key if provided, otherwise use the custom key
            keyBuilder.Append($"_{_customKey ?? context.HttpContext.Request.Path}");

            return keyBuilder.ToString();
        }
    }
}