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
    public class EFCourseRepository : ICourseRepository
    {
        private readonly CourseDbContext courseDbContext;
        public EFCourseRepository(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }
        public async Task CreateAsync(Course entity)
        {
            await courseDbContext.Courses.AddAsync(entity);
            await courseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAync(int id)
        {
            var deletingCourse = await courseDbContext.Courses.FindAsync(id);
            courseDbContext.Courses.Remove(deletingCourse);
            await courseDbContext.SaveChangesAsync();
        }

        public Course? Get(int id)
        {
            return courseDbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public IList<Course?> GetAll()
        {
            return courseDbContext.Courses.AsNoTracking().ToList();
        }

        public async Task<IList<Course?>> GetAllAsync()
        {
            return await courseDbContext.Courses.AsNoTracking().ToListAsync();
        }

        public IList<Course> GetAllWithPredicate(Expression<Func<Course, bool>> predicate)
        {
            return courseDbContext.Courses.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<Course?> GetAsync(int id)
        {
            return await courseDbContext.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Course> GetCourseByCategory(int categoryId)
        {
            return courseDbContext.Courses.AsNoTracking().Where(c => c.CategoryId == categoryId).AsEnumerable();
        }

        public IEnumerable<Course> GetCoursesByName(string name)
        {
            return courseDbContext.Courses.AsNoTracking().Where(c => c.CategoryId == categoryId).AsEnumerable();

        }

        public async Task UpdateAsync(Course entity)
        {
            courseDbContext.Courses.Update(entity);
            await courseDbContext.SaveChangesAsync();
        }
    }
}
