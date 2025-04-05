using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace TerrainApp.API
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate? next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate? next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                 await this.next(context);
            }
            catch (Exception ex)
            {
               

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.Error.WriteLine(exception);

            var statusCode = HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                error = new
                {
                    message = "internal server error" + exception.ToString(),
                },
            };

            var jsonResponse = JsonSerializer.Serialize(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
