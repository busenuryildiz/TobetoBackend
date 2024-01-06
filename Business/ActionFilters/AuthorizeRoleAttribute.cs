//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
//public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
//{
//    private readonly string[] _roles;

//    public AuthorizeRoleAttribute(params string[] roles)
//    {
//        _roles = roles;
//    }

//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        var userRoles = context.HttpContext.Items["UserRoles"] as IEnumerable<string>;

//        if (userRoles == null || !_roles.Any(role => userRoles.Contains(role)))
//        {
//            context.Result = new ForbidResult(); // Unauthorized
//        }
//    }
//}
