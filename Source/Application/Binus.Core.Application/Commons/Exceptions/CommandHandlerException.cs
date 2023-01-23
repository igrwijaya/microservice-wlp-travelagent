using System;

namespace Binus.Core.Application.Commons.Exceptions
{
    public class CommandHandlerException : Exception
    {
        public CommandHandlerException(string eventHandlerName, string message)
            : base($"{eventHandlerName} -- {message}")
        {
            
        }
    }
}