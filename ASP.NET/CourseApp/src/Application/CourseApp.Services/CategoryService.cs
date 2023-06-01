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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this._mapper = mapper;
        }
        public IEnumerable<CategoryDisplayResponse> GetCategoryDisplayResponses()
        {
            var categories = categoryRepository.GetAll();
            var response = categories.ConvertToCategoryDisplayResponses(_mapper);
            return response;
        }
    }
}
