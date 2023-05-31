using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public IActionResult Index(int pageNo = 1)
        {
            var courses = _courseService.GetCourseDisplayResponse();
            /*
                1.sayfa : 0 eleman atla, 8 eleman al
                2.sayfa : 8 eleman atla, 8 eleman al 
                3.sayfa = 16 eleman atla, 8 eleman al
             */

            /*
             Kursların toplam sayfa sayısı için gerekli bilgiler ;
                -sayfada kaç kurs olacak
                -toplam kaç kurs var
             */

            var coursePerPage = 8;
            var courseCount = courses.Count();
            var totalPage = Math.Ceiling((decimal)courseCount / coursePerPage);//yukarıya tamamladık 105 yerine 106 olursa, her sayfaya 5 tane olursa diye eksik sayfa olmasın
            ViewBag.TotalPage = totalPage;

            var paginatedCourses = courses.OrderBy(c => c.Id)
                                          .Skip((pageNo-1)*coursePerPage)
                                          .Take(coursePerPage)
                                          .ToList();

            return View(paginatedCourses);
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