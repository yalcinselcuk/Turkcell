using CustomMiddlewares.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//AddControllersVithViews değil, API yazan birisi View düşünmez 
//API yazan birisi JSON dondurur
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

using var loggerFactory = LoggerFactory.Create(builder => builder.AddSimpleConsole());//middleware içinde logger aldığımızdan instance'ını böyle oluşturduk
var logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
//bu iki satırın amacı middleware içindeki ILogger'ı döndürmek

var app = builder.Build();

//app.Use(async(context, next) =>
//{
//    await context.Response.WriteAsync("---");
//    await next();//bir sonraki middleware'e gönderdik, yani aşağıya
//    await context.Response.WriteAsync("---");//bir daha buraya dönüyorsa bunu döndürecek
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync(">>>");
//    await next();//bir sonraki middleware'e gönderdik
//    await context.Response.WriteAsync("<<<");//bir daha buraya dönüyorsa bunu döndürecek
//});

//Http'den gelen bütün request'leri yakalaması için temsilen "context" dedik
//her yapılan işlem bşr middleware olduğundan context'ten sonra bir sonraki middleware'e göndermemiz gerekir
//onu da temsilen "next" diyoruz

app.UseMiddleware<RequestLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<JsonBodyMiddleware>();
app.UseMiddleware<BadWordsHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Bunu middleware yazdı");
//});
app.Run();
