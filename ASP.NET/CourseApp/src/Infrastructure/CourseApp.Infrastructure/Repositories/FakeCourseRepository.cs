using CourseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Repositories
{
    public class FakeCourseRepository : ICourseRepository
    {
        private List<Course> _courses;
        public FakeCourseRepository()
        {
            _courses = new()
            {
                new Course {Id=1, Name="Course 1", Description="Description 1", Price=1, Rating=1, TotalHours=10},
                new Course {Id=2, Name="Course 2", Description="Description 2", Price=2, Rating=2, TotalHours=20},
                new Course {Id=1, Name="Course 3", Description="Description 3", Price=3, Rating=3, TotalHours=30},
                new Course {Id=1, Name="Course 4", Description="Description 4", Price=4, Rating=4, TotalHours=40}


            };
        }
        public Course? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Course?> GetAll()
        {
            return _courses;
        }

        public Task<IList<Course?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCourseByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
