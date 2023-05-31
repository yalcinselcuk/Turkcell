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
        public HomeController(ILogger<HomeController> logger, ISingletonGuid singletonGuid, ITransientGuid transientGuid, IScopedGuid scopedGuid)
        {
            _logger = logger;
            this.singletonGuid = singletonGuid;
            this.transientGuid = transientGuid;
            this.scopedGuid = scopedGuid;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonGuid = singletonGuid.Guid.ToString();
            ViewBag.TransientGuid = transientGuid.Guid.ToString();
            ViewBag.ScopedGuid = scopedGuid.Guid.ToString();
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