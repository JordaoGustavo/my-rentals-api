using System;
using System.Net;

namespace my_rentals.Application.Exceptions
{
    public class ApiValidationException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ApiValidationException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            StatusCode = httpStatusCode;
        }
    }
}
