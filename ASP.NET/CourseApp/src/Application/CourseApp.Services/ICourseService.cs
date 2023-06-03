using CourseApp.DataTransferObjects.Requests;
using CourseApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Services
{
    public interface ICourseService
    {
        CourseDisplayResponse GetCourse(int id);
        IEnumerable<CourseDisplayResponse> GetCourseDisplayResponse();
        IEnumerable<CourseDisplayResponse> GetCoursesByCategory(int categoryId);
        Task CreateCourseAsync(CreateNewCourseRequest createNewCourseRequest);
    }
}
