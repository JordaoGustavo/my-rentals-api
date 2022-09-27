using System;
using System.Net;

namespace my_rental.Domain.Seedwork.Exceptions
{
    public abstract class DomainException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public DomainException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            StatusCode = httpStatusCode;
        }
    }
}
