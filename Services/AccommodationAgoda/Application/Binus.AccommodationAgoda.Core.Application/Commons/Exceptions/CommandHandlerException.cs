using System;

namespace Binus.AccommodationAgoda.Core.Application.Commons.Exceptions
{
    public class CommandHandlerException : Exception
    {
        public CommandHandlerException(string eventHandlerName, string message)
            : base($"{eventHandlerName} -- {message}")
        {
            
        }
    }
}