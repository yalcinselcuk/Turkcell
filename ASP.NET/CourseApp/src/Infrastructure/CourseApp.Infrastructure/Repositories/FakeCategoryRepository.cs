using CourseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public FakeCategoryRepository()
        {
            _categories = new List<Category>()
                {
                    new Category{Id=1, CategoryName="Language"},
                    new Category{Id=2, CategoryName="Programming"},
                    new Category{Id=3, CategoryName="Philosophy"}
                };
        }

        public Task CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAync(int id)
        {
            throw new NotImplementedException();
        }

        public Category? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category?> GetAll()
        {
            return _categories;
        }

        public Task<IList<Category?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAllWithPredicate(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Category>.UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
