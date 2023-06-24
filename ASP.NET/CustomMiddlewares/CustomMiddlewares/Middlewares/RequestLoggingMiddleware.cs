namespace CustomMiddlewares.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;//kendisinden sonra nereye gideceği
        private readonly ILogger<RequestLoggingMiddleware> _logger;//loglamak için ve bu klasöre özgü oluşturduk

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext  httpContext)//middleware çalıştığında bu fonksiyon çalışır
        {
            /*
             * Bu middleware'in amacı:  api'ye gelen her request'i yakalamak ve bilgi vermektir
             */
            _logger.LogInformation($"Gelen request metodu : {httpContext.Request.Method}. Talebin gönderildiği adres : {httpContext.Request.Path}");
            await _next(httpContext);//middleware'i gönderdik
        }
    }
}
