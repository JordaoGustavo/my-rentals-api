using System.Net;

namespace my_rental.Domain.Seedwork.Exceptions
{
    public class InvalidDomainOperationException : DomainException
    {
        public InvalidDomainOperationException(string message) : base(message, HttpStatusCode.UnprocessableEntity)
        {
        }
    }
}
