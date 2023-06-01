using CourseApp.DataTransferObjects.Responses;

namespace CourseApp.Mvc.Models
{
    public class PaginationCourseViewModel
    {
        // her view bir modelle çalışacağından ve biz iki modeli bir view'de kullanmak istediğimizden
        // gidip iki modelden de birer tane instance oluştururuz 3.modelde ve bu modeli kullanırız
        public IEnumerable<CourseDisplayResponse> Courses { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
