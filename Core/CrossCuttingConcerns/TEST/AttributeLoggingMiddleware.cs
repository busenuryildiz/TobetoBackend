//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using System;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace Core.CrossCuttingConcerns.Exceptions
//{
//    public class AttributeLoggingMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public AttributeLoggingMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            // Get the controller instance using HttpContext.Request.Controller
//            var controller = context.Request.Controller;

//            if (controller is not null)
//            {
//                var controllerActionDescriptor = controller.ActionDescriptor as ControllerActionDescriptor;
//                if (controllerActionDescriptor is not null)
//                {
//                    var controllerName = controllerActionDescriptor.ControllerName;
//                    var actionName = controllerActionDescriptor.ActionName;

//                    Console.WriteLine($"Controller: {controllerName}, Action: {actionName}");

//                    var attributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);

//                    // ... rest of your code
//                }
//            }

//            await _next(context);
//        }
//    }
//}
