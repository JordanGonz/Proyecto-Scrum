using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Scrum.Core.Contracts;
using Scrum.Core.Models.ApiResponse;

namespace Scrum.Core.Common
{
    internal class ExceptionsHandler : IExceptionHandler
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
}
