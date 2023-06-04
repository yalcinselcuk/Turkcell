using CourseApp.DataTransferObjects.Requests;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseApp.Mvc.Controllers
{
    [Authorize(Roles ="Admin, Editor")]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly ICategoryService categoryService;
        public CoursesController(ICourseService courseService, ICategoryService categoryService)
        {
            this.courseService = courseService;
            this.categoryService = categoryService;
        }
         
        public IActionResult Index()
        {
            var courses = courseService.GetCourseDisplayResponse();
            return View(courses);
        }
        public async Task <IActionResult> Create()
        {
            ViewBag.Categories = getCategoriesForSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewCourseRequest createNewCourseRequest)
        {
            if (ModelState.IsValid)
            {
                await courseService.CreateCourseAsync(createNewCourseRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = getCategoriesForSelectList();
            return View();
        }

        private IEnumerable<SelectListItem> getCategoriesForSelectList()
        {
            var categories = categoryService.GetCategoryDisplayResponses().Select(c => new SelectListItem { Text = c.CategoryName, Value = c.Id.ToString() }).ToList();
            categories.Insert(0, new SelectListItem { Text = "Seçiniz", Value = string.Empty });
            return categories;
        }
    }
}
