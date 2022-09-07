using Azure;
using System.Text;

namespace BusReservations.WebAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);

            //var originalBodyStream = context.Response.Body;

            //using var responseBody = new MemoryStream();
            //context.Response.Body = responseBody;

            await _next(context);

            //var response = await FormatResponse(context.Response);
            //context.Response.Body = originalBodyStream;

            _logger.LogInformation(request);
            _logger.LogInformation($"\nResponse:\n" +
                $"Status: {context.Response.StatusCode}\n");
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Seek(0, SeekOrigin.Begin);

            return $"\nRequest:\n" +
                $"Scheme: {request.Scheme}\n" +
                $"Host: {request.Host}\n" +
                $"Path: {request.Path}\n" +
                $"Query: {request.QueryString}\n" +
                $"Body: {bodyAsText}\n";
        }

        //private static async Task<string> FormatResponse(HttpResponse response)
        //{
        //    response.Body.Seek(0, SeekOrigin.Begin);

        //    string text = await new StreamReader(response.Body).ReadToEndAsync();

        //    response.Body.Seek(0, SeekOrigin.Begin);


        //    return $"\nResponse:\n" +
        //        $"Status: {response.StatusCode}\n" +
        //        $"Body: {text}";
        //}
    }
}
