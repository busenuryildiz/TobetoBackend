using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.MiddlewareAspects
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class LogActionTypeAttribute : Attribute
    {
        public string ActionType { get; }

        public LogActionTypeAttribute(string actionType)
        {
            ActionType = actionType;
        }
    }
}
