using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMM.Common
{
    public class DuplicateGuidDbProblemDetails : ProblemDetails
    {
        public DuplicateGuidDbProblemDetails(DbUpdateException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Source;
            Type = $"https://httpstatuses.com/{Status}";
        }
    }
}
