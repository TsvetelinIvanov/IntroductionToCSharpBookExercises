using System;

namespace _06ValidateArithmeticalExpression
{
    public class ValidationException : Exception
    {
        private const string InvalidVoalidationExceptionMessage = "Invalid expression!";

        public ValidationException() : base(InvalidVoalidationExceptionMessage)
        {

        }

        public ValidationException(string message) : base(message)
        {

        }
    }
}