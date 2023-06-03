using CourseApp.Mvc.Extensions;
using CourseApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CourseApp.Mvc.ViewComponents
{
    public class SepetLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var courseCollection = HttpContext.Session.GetJson<CourseCollection>("sepetim");
          
            return View(courseCollection);
        }
    }
}
