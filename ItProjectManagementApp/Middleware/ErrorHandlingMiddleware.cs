using Domain.Exceptions;

namespace ItProjectManagementApp.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException, argumentException.Message);

                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(argumentException.Message);
            }
            catch (ApplicationException applicationException)
            {
                _logger.LogError(applicationException, applicationException.Message);

                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(applicationException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                _logger.LogError(notFoundException, notFoundException.Message);

                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
