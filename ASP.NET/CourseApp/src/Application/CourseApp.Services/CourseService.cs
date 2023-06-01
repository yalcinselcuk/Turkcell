using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository CourseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository CourseRepository, IMapper _mapper)
        {
            this.CourseRepository = CourseRepository;
            this._mapper = _mapper;
        }
        public IEnumerable<CourseDisplayResponse> GetCourseDisplayResponse()
        {
            var courses = CourseRepository.GetAll();
            var response = courses.ConvertToDisplayResponses(_mapper);
            return response;
        }

        public IEnumerable<CourseDisplayResponse> GetCoursesByCategory(int categoryId)
        {
            var courses = CourseRepository.GetCourseByCategory(categoryId);
            var response = courses.ConvertToDisplayResponses(_mapper);
            return response;
        }
    }
}
