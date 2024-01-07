using System;
using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Redis;

namespace Core.Aspects.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RemoveCacheAttribute : ActionFilterAttribute
    {
        private readonly RedisService _redisService = new RedisService();
        private readonly IDatabase _database;

        // RemoveCacheAttribute tarafından belirlenecek özel parametre
        public string CacheKey { get; set; }

        public RemoveCacheAttribute()
        {
            _database = _redisService.GetDatabase();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!string.IsNullOrEmpty(CacheKey))
            {
                var keysToRemove = GetKeysByCacheKey(CacheKey);

                foreach (var key in keysToRemove)
                {
                    _database.KeyDelete(key);
                }
            }

            base.OnActionExecuted(context);
        }

        private IEnumerable<RedisKey> GetKeysByCacheKey(string cacheKey)
        {
            var pattern = $"*{cacheKey}*";

            var multiplexer = _database.Multiplexer.GetServer(_database.Multiplexer.GetEndPoints().First());
            var keys = multiplexer.Keys(pattern: pattern);

            Console.WriteLine($"Multiplexer: {multiplexer}");
            Console.WriteLine($"Multiplexer: {_database.Multiplexer}");

            foreach (var key in keys)
            {
                Console.WriteLine($"Key: {key}");
            }

            return keys;
        }
    }
}
