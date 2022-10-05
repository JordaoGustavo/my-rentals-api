using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using my_rental.Domain.Seedwork.Exceptions;

namespace my_rentals.API.Extentions
{
    public static class ControllerExtentions
    {
        public static IActionResult ToOk<TResult, TContract>(this Result<TResult> result, Func<TResult, TContract> mapper)
        {
            return result.Match<IActionResult>(obj =>
            {
                var response = mapper(obj);
                return new OkObjectResult(response);
            }, exception =>
            {
                if (exception is InvalidDomainOperationException domainException)
                {
                    return new UnprocessableEntityObjectResult(domainException.Message);
                }

                if (exception is NotFoundException notFoundException)
                {
                    return new NotFoundObjectResult(notFoundException.Message);
                }

                return new StatusCodeResult(500);
            });
        }
    }
}
