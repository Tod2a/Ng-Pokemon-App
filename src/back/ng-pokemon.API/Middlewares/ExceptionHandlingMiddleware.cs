using ng_pokemon.Domain.Exceptions;
using Serilog;

namespace ng_pokemon.API.Middlewares;

/// <summary>
/// Middleware that handles exceptions globally in the API pipeline.
/// Catches known exceptions (like <see cref="NotFoundException"/>) and
/// converts them into appropriate HTTP responses.
/// </summary>
public class ExceptionHandlingMiddleware(RequestDelegate next, Serilog.ILogger logger)
{
    private readonly RequestDelegate _next = next;
    private readonly Serilog.ILogger _logger = logger;

    /// <summary>
    /// Invokes the middleware for the current HTTP context.
    /// </summary>
    /// <param name="context">The HTTP context of the current request.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// This method catches exceptions thrown by downstream middlewares or controllers.
    /// - If a <see cref="NotFoundException"/> is thrown, returns HTTP 404 with the exception message.
    /// - For all other exceptions, returns HTTP 500 with a generic error message.
    /// </remarks>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.Error(ex, "NotFound exception occurred.");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An unexpected error occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Internal server error");
        }
    }
}
