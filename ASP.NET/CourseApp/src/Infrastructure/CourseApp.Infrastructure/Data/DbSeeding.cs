using CourseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(CourseDbContext dbContext)
        {
            seedCategoryIfNotExist(dbContext);
            seedCourseIfNotExist(dbContext);
        }

        private static void seedCategoryIfNotExist(CourseDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category{CategoryName = "Yabancı Dil Kursları",Description="..."},
                    new Category{CategoryName = "Kişisel Gelişim Kursları",Description="..."},
                    new Category{CategoryName = "Yazılım Geliştirme Kursları",Description="..."}
                };
                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
            }
        }

        private static void seedCourseIfNotExist(CourseDbContext dbContext)
        {
            if (!dbContext.Courses.Any())
            {
                var courses = new List<Course>()
                {
                    new Course{ Name="İngilizce", Description="Description 1", Price=10, Rating=4, TotalHours=10, ImageUrl="https://loremflickr.com/320/240", CategoryId=1},
                    new Course{ Name="Hafıza Güçlendirme", Description="Description 2", Price=20, Rating=3, TotalHours=10, ImageUrl="https://loremflickr.com/320/240",CategoryId=2},
                    new Course{ Name="ASP.NETCore", Description="Description 3", Price=30, Rating=5, TotalHours=10, ImageUrl="https://loremflickr.com/320/240",CategoryId=3},
                    new Course{ Name="Almanca", Description="Description 4", Price=40, Rating=4, TotalHours=10, ImageUrl="https://loremflickr.com/320/240",CategoryId=1},
                    new Course{ Name="Stresle Başa Çıkma", Description="Description 5", Price=50, Rating=3, TotalHours=10, ImageUrl="https://loremflickr.com/320/240",CategoryId=2},
                    new Course{ Name="Angular JS", Description="Description 6", Price=60, Rating=5, TotalHours=10, ImageUrl = "https://loremflickr.com/320/240", CategoryId=3},

                };
                dbContext.Courses.AddRange(courses);
                dbContext.SaveChanges();
            }
        }
    }
}
