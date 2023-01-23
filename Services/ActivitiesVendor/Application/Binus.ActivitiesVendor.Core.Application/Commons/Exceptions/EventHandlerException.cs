using System;

namespace Binus.ActivitiesVendor.Core.Application.Commons.Exceptions
{
    public class EventHandlerException : Exception
    {
        public EventHandlerException(string eventHandlerName, string message)
            : base($"{eventHandlerName} -- {message}")
        {
            
        }
    }
}