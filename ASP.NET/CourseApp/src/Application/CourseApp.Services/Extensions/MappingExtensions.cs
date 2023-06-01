using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Services.Extensions
{
    public static class MappingExtensions
    {
        public static T ConvertToDto<T>(this IEnumerable<Course> courses, IMapper mapper)
        {
            return mapper.Map<T>(courses);
        }
        public static IEnumerable<CourseDisplayResponse> ConvertToDisplayResponses(this IEnumerable<Course> courses, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CourseDisplayResponse>>(courses);
        }
        public static IEnumerable<CategoryDisplayResponse> ConvertToCategoryDisplayResponses(this IEnumerable<Category> categories, IMapper mapper)
        {
            return mapper.Map<IEnumerable<CategoryDisplayResponse>>(categories);
        }
    }
}
