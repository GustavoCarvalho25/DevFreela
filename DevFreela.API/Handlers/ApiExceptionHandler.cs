using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Handlers
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
            };

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }
    }
}
