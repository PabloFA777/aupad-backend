using System.Net;
using System.Text.Json;

namespace Aupad.DesarrolloApiNet.Api
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;
        private const string HeaderRequerido = "X-Aupad-Client";

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Validación de header requerido
            if (!context.Request.Headers.ContainsKey(HeaderRequerido))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    mensaje = $"El header '{HeaderRequerido}' es requerido para consumir esta API."
                }));
                return;
            }

            // 2. Manejo global de errores
            try
            {
                await _next(context);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Conflicto de negocio");
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    mensaje = ex.Message
                }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    mensaje = "Ocurrió un error interno. Contacte al administrador."
                }));
            }
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}