using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Scrum.Core.Contracts.Middleware;
using Scrum.Core.Models.ApiResponse;

namespace Scrum.Core.Common
{
    public class GenericExceptionHandler : IExceptionHandler
    {
        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            string mensajeExcepcion = String.Empty;

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            mensajeExcepcion = $"Error principal: {exception.Message}, Ubicacion: {exception.StackTrace}\n";

            if (exception.InnerException is not null)
                mensajeExcepcion += $"Excepcion interna: {exception.InnerException.Message}";

            var result = JsonSerializer.Serialize(new Response<object>
            {
                Success = false,
                Message = mensajeExcepcion
            }
            );
            await response.WriteAsync(result);
        }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionHandler _exceptionHandler;

        public ExceptionMiddleware(RequestDelegate next, IExceptionHandler exceptionHandler)
        {
            _next = next;
            _exceptionHandler = exceptionHandler;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await _exceptionHandler.HandleAsync(httpContext, ex);
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
