using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        //bu metod bizim hangi view'le çalışacağımızı bulan ve döndüren metod
        public IActionResult Index()
        {
            ViewBag.Name = "Yalcin";
            ViewBag.Month = DateTime.Now.Month;
            ViewBag.Year = DateTime.Now.Year;
            return View();
        }

        public IActionResult Privacy()
        {
            var privacy = new Privacy { Header = "Gizlilik", Info = "Bu uygulama çerezleri kullanır" };
            return View(privacy);
        }
        public IActionResult Register() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Register(Register values) 
        {
            var items = values;
            return View();
        }
        [HttpPost]
        public IActionResult Registerr(Register values)
        {
            var items = values;
            return View();
        }
    }
}
