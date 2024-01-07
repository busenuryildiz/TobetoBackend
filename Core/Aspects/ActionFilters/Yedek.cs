//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using Core.DataAccess.Paging;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Serilog;
//using StackExchange.Redis;

//namespace Core.Aspects.ActionFilters
//{
//    public class RedisCacheAttribute : ActionFilterAttribute
//    {
//        private readonly RedisService _redisService = new RedisService();
//        private readonly IDatabase _database;
//        private readonly ILogger _logger;

//        public RedisCacheAttribute(ILogger logger)
//        {
//            _database = _redisService.GetDatabase();
//            _logger = logger;
//        }

//        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            var key = GenerateCacheKey(context);



//            var cachedValue = await _database.StringGetAsync(key);

//            if (cachedValue.HasValue)
//            {
//                _logger.Information("Cache hit. Key: {Key}", key);

//                context.Result = new ContentResult
//                {
//                    Content = cachedValue,
//                    ContentType = "application/json",
//                    StatusCode = 200
//                };
//                return;
//            }

//            var resultContext = await next();




//            if (resultContext?.Result is ObjectResult objectResult1 && objectResult1.Value != null)
//            {
//                var jsonResult = JsonConvert.SerializeObject(objectResult1.Value);
//                await _database.StringSetAsync(key, jsonResult);
//                Console.WriteLine(jsonResult);
//                _logger.Information($"Anahtar: {key}, İşlem: Redis'e ekleniyor");
//                context.Result = new ContentResult
//                {
//                    Content = jsonResult,
//                    ContentType = "application/json",
//                    StatusCode = 200
//                };
//            }
//            else
//            {
//                _logger.Error($"Anahtar: {key}, İşlem: Redis'e eklenirken Items özelliği beklenen türde değil.");
//            }
//        }


//        private string GenerateCacheKey(ActionExecutingContext context)
//        {
//            var keyBuilder = new StringBuilder();
//            keyBuilder.Append(context.ActionDescriptor.DisplayName);
//            keyBuilder.Append(context.HttpContext.Request.Path);
//            foreach (var (key, value) in context.ActionArguments)
//            {
//                keyBuilder.Append($"_{key}_{value}");
//            }

//            return keyBuilder.ToString();
//        }
//    }
//}