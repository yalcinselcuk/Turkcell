using CourseApp.Entities;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly CourseDbContext courseDbContext;
        public EFCategoryRepository(CourseDbContext courseDbContext)
        {
                this.courseDbContext = courseDbContext;
        }
        public async Task CreateAsync(Category entity)
        {
            await courseDbContext.Categories.AddAsync(entity);
            await courseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAync(int id)
        {
            var deletingCategory = await courseDbContext.Categories.FindAsync(id);
            courseDbContext.Categories.Remove(deletingCategory);
            await courseDbContext.SaveChangesAsync();
        }

        public Category? Get(int id)
        {
            return courseDbContext.Categories.FirstOrDefault(c => c.Id == id);  
        }

        public IList<Category?> GetAll()
        {
            return courseDbContext.Categories.AsNoTracking().ToList();
        }

        public async Task<IList<Category?>> GetAllAsync()
        {
            return await courseDbContext.Categories.AsNoTracking().ToListAsync();
        }

        public IList<Category> GetAllWithPredicate(Expression<Func<Category, bool>> predicate)
        {
            return courseDbContext.Categories.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await courseDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            courseDbContext.Categories.Update(entity);
            await courseDbContext.SaveChangesAsync();
        }
    }
}
