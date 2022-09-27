using System.Net;

namespace my_rental.Domain.Seedwork.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
