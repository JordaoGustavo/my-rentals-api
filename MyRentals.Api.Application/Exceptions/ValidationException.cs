using System;
using System.Collections.Generic;

namespace MyRentals.Api.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IEnumerable<string> ValidationErrors { get; set; }

        public ValidationException(IEnumerable<string> errors)
        {
            ValidationErrors = new Stack<string>(errors);
        }
    }
}
