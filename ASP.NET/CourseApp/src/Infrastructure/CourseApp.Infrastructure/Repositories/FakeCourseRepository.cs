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
                new Course {Id=1, Name="Course 1", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId=1},
                new Course {Id=2, Name="Course 2", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId=1},
                new Course {Id=3, Name="Course 3", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 1},
                new Course {Id=4, Name="Course 4", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 1},
                new Course {Id=5, Name="Course 5", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId = 1},
                new Course {Id=6, Name="Course 6", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId = 1},
                new Course {Id=7, Name="Course 7", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 1},
                new Course {Id=8, Name="Course 8", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 1}, 
                new Course {Id=9, Name="Course 9", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId = 2},
                new Course {Id=10, Name="Course 10", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId = 2},
                new Course {Id=11, Name="Course 11", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 2},
                new Course {Id=12, Name="Course 12", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 2},
                new Course {Id=13, Name="Course 13", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId = 2},
                new Course {Id=14, Name="Course 14", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId = 2},
                new Course {Id=15, Name="Course 15", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 2},
                new Course {Id=16, Name="Course 16", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 2},
                new Course {Id=17, Name="Course 17", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId = 3},
                new Course {Id=18, Name="Course 18", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId = 3},
                new Course {Id=19, Name="Course 19", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 3},
                new Course {Id=20, Name="Course 20", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 3},
                new Course {Id=21, Name="Course 21", Description="Description 1", Price=1, Rating=1, TotalHours=10, CategoryId = 3},
                new Course {Id=22, Name="Course 22", Description="Description 2", Price=2, Rating=2, TotalHours=20, CategoryId = 3},
                new Course {Id=23, Name="Course 23", Description="Description 3", Price=3, Rating=3, TotalHours=30, CategoryId = 3},
                new Course {Id=24, Name="Course 24", Description="Description 4", Price=4, Rating=4, TotalHours=40, CategoryId = 3}


            };
        }
        public Course? Get(int id)
        {
            return _courses.Find(c => c.Id == id);
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
            return _courses.Where(c => c.CategoryId == categoryId).AsEnumerable();
        }

        public IEnumerable<Course> GetCoursesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
