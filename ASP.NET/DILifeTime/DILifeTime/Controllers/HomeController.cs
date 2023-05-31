using DILifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DILifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuid singletonGuid;
        private readonly ITransientGuid transientGuid;
        private readonly IScopedGuid scopedGuid;
        private readonly GuidService guidService;
        public HomeController(ILogger<HomeController> logger, ISingletonGuid singletonGuid, ITransientGuid transientGuid, 
                                                                    IScopedGuid scopedGuid, GuidService guidService)
        {
            _logger = logger;
            this.singletonGuid = singletonGuid;
            this.transientGuid = transientGuid;
            this.scopedGuid = scopedGuid;
            this.guidService = guidService;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonGuid = singletonGuid.Guid.ToString();
            //Constructor bir kere çalıştı, singleton'ı üretti ve üretmedi proje boyunca.Hep aynı instance'ı kullandı
            ViewBag.TransientGuid = transientGuid.Guid.ToString();
            ViewBag.ScopedGuid = scopedGuid.Guid.ToString();

            ViewBag.SingletonService = guidService.SingletonGuid.Guid.ToString();
            ViewBag.TransientService = guidService.TransientGuid.Guid.ToString();
            ViewBag.ScopedService = guidService.ScopedGuid.Guid.ToString();
            //belli alanda / bir yerde kullanılınca scoped da bir kere üretildi
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}