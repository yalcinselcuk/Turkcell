using CourseApp.DataTransferObjects.Responses;
using CourseApp.Mvc.Extensions;
using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CourseApp.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ICourseService courseService;
        public ShoppingController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            var courseCollection = getCourseCollectionFromSession();
            return View(courseCollection);
        }
        public IActionResult AddCourse(int id)
        {
            CourseDisplayResponse selectedCourse = courseService.GetCourse(id);

            var courseItem = new CourseItem { Course = selectedCourse, Quantity = 1 };
            CourseCollection courseCollection = getCourseCollectionFromSession();
            courseCollection.AddNewCourse(courseItem);
            saveToSession(courseCollection);

            return Json(new { message = $"{selectedCourse.Name} Sepete Eklendi " });
        }

        private CourseCollection getCourseCollectionFromSession()
        {
            //var serializedString = HttpContext.Session.GetString("sepetim");
            ////ilk kez sepete kurs ekleniyorsa serializedstring boş olacak
            //if (serializedString == null)//sepete ilk defa bir şey ekleniyor, sepet oluşmamış 
            //{
            //    return new CourseCollection();// yeni bir instance oluştur
            //}
            //// içine girmezse demek ki önceden "sepetim" diye bir session oluşmuş ve içine bir şey atılmış
            //var collection = JsonSerializer.Deserialize<CourseCollection>(serializedString);// geri serileştir
            //return collection;
            return HttpContext.Session.GetJson<CourseCollection>("sepetim") ?? new CourseCollection();
        }
        private void saveToSession(CourseCollection courseCollection)
        {
            //var serialized = JsonSerializer.Serialize<CourseCollection>(courseCollection);
            //if (!string.IsNullOrWhiteSpace(serialized)) //serialized değilse
            //{
            //    HttpContext.Session.SetString("sepetim", serialized);
            //}
            HttpContext.Session.SetJson("sepetim", courseCollection);
        }

    }
}
