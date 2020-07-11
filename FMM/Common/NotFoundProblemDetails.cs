using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMM.Common
{
    public class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(NotFoundException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status404NotFound;
            Detail = exception.Details;
            Type = $"https://httpstatuses.com/{Status}";
        }
    }
}
