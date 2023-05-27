namespace FirstMVCApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            var message = app.Configuration.GetSection("Message")["meet"];

            //app.MapGet("/", () => message);

            app.UseRouting();
            //app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            //daha evrenselini kullanalım;
            app.UseStaticFiles();
            app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

            //app.Use... ==> Use ile başlayanların hepsi MiddleWare'dır.
            //MiddleWare : gelen tüm request'leri tutup yönlendirir.
            //Middleware 'lerin arasında sıralama vardır = pipeline

            app.Run();
        }
    }
}