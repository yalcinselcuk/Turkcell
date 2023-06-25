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
            _logger.LogInformation($"{DateTime.Now} anında Gelen request metodu : {httpContext.Request.Method}. Talebin gönderildiği adres : {httpContext.Request.Path}");
            
            // 1.oluşacak olan yanıtı responseBodyStream değişkeninde tut
            var responseBodyStream = httpContext.Response.Body; //üretilen çıktının sonucunu almak istiyoruz

            // 2. yeni bir memoryStream oluştur
            var responseStream = new MemoryStream();//bellekte bir alan oluşturduk
            
            // 3.var olan httpContext'in response'u memoryStream referansıyla aynı olsun
            httpContext.Response.Body = responseStream;//oluşturulan alanı aktar, var olan Body'i responseStream'le değiştir
            
            // 4.response'u oluşturmak üzere git
            await _next(httpContext);//middleware'i gönderdik, response'u döndürdü büyük ihtimal
            responseStream.Seek(0, SeekOrigin.Begin);//başlangıç pozisyonuna dönücez

            // oluşan responseStream'i responseBody'e kopyala
            var responseBody = new StreamReader(responseStream).ReadToEnd();//belirttiğimiz responseStream'i baştan sona oku
            _logger.LogInformation($"{DateTime.Now} anında  Response oluştu...");
            _logger.LogInformation($"Oluşan response : {httpContext.Response.StatusCode} -> {responseBody}");

            responseStream.Seek(0, SeekOrigin.Begin);
            //istemciye yanıt vermesi için responseStream'i tekrar responseBodyStream'e kopyala
            await responseStream.CopyToAsync(responseBodyStream);

        }
    }
}
