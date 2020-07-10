using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMM.Common
{
    public class InvalidValidationProblemDetails : ProblemDetails
    {
        public InvalidValidationProblemDetails(InvalidValidationException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Details;
            Type = $"https://httpstatuses.com/{Status}";
        }
    }
}