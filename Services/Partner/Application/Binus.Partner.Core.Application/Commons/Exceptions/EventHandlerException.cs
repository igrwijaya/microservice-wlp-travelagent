using System;

namespace Binus.Partner.Core.Application.Commons.Exceptions
{
    public class EventHandlerException : Exception
    {
        public EventHandlerException(string eventHandlerName, string message)
            : base($"{eventHandlerName} -- {message}")
        {
            
        }
    }
}