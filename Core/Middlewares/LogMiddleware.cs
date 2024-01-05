//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Core.Utilities.MiddlewareAspects;

//namespace Core.Middlewares
//{
//    public class LogMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<LogMiddleware> _logger;

//        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

//            // Kontrol edilecek attribute'ü al
//            var logAttribute = endpoint?.Metadata.GetMetadata<LogActionTypeAttribute>();

//            if (logAttribute != null)
//            {
//                var actionType = logAttribute.ActionType;
//                // Özel loglama işlemi
//                _logger.LogInformation($"Executing action with type: {actionType}");
//            }

//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//            // Middleware zincirinin bir sonraki adımına geç
//            await _next(context);



//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//            Console.WriteLine("LOGLAMA ÇALIŞTI");
//        }
//    }
//}
