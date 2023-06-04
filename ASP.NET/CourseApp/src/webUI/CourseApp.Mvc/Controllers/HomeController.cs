using CourseApp.DataTransferObjects.Responses;
using CourseApp.Mvc.CacheTools;
using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CourseApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
        private readonly IMemoryCache _memoryCache;
        public HomeController(ILogger<HomeController> logger, ICourseService courseService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _courseService = courseService;
            _memoryCache = memoryCache;
        }

        public IActionResult Index(int pageNo = 1, int? id = null)//category boş da dönebilir diye null ekledik
        {
            IEnumerable<CourseDisplayResponse> courses = GetCoursesMemoryCacheOrDb(id);
            // id sıfırsa demek ki bir category yok, normal çalışacak (yani GetCourseDisplayResponse)
            // ama değilse o zaman GetCourseByCategory çalışır 

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

            var coursePerPage = 4;
            var courseCount = courses.Count();
            var totalPage = Math.Ceiling((decimal)courseCount / coursePerPage);//yukarıya tamamladık 105 yerine 106 olursa, her sayfaya 5 tane olursa diye eksik sayfa olmasın

            var paginationInfo = new PaginationInfo
            {
                CurrentPage = pageNo,
                ItemsPerPage = coursePerPage,
                TotalItems = courseCount
            };


            var paginatedCourses = courses.OrderBy(c => c.Id)
                                          .Skip((pageNo - 1) * coursePerPage)
                                          .Take(coursePerPage)
                                          .ToList();

            var model = new PaginationCourseViewModel
            {
                Courses = paginatedCourses,
                PaginationInfo = paginationInfo
            };

            return View(model);
        }

        private IEnumerable<CourseDisplayResponse> GetCoursesMemoryCacheOrDb(int? id)
        {
            //eğer cache'ta varsa cache'ten çek, yoksa kaynaktan çek cache'e at
            if (!_memoryCache.TryGetValue("allCourses", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal);
                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Courses = _courseService.GetCourseDisplayResponse()
                };
                _memoryCache.Set("allCourses", cacheDataInfo, options);
            }

            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");

            return id == null ? cacheDataInfo.Courses :
                                _courseService.GetCoursesByCategory(id.Value);
        }

        [ResponseCache(Duration =70, VaryByQueryKeys = new[] {"id"}, Location =ResponseCacheLocation.Client)]
        public IActionResult Privacy(int id)
        {
            ViewBag.Id = id;
            ViewBag.DateTime = DateTime.Now;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}