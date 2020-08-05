using System;

namespace FMM.Common
{
    public class InvalidValidationException : Exception
    {
        public string Details { get; }
        public InvalidValidationException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}