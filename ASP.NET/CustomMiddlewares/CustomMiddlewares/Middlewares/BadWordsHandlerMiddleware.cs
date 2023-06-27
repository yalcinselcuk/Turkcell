namespace CustomMiddlewares.Middlewares
{
    public class BadWordsHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public BadWordsHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var jsonBody = (string)context.Items["JsonBody"];//önceki middleware'daki elemanı alıyoruz
            var badWords = new List<string>
            {
                "pis", "manyak", "kötü", "kelime"
            };
            bool isContainBadWords = badWords.Any(w => jsonBody.Contains(w));//her kötü kelimenin jsonBody içinde yer alıp almadığını bana söylesin

            if (isContainBadWords)//true ise badRequest döndürsün
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { message = "gönderdiğiniz yorumda hoş olmayan ifadeler var" });
                return;
            }
            await _next(context);
        }
    }
}
