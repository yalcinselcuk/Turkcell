﻿using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Mvc.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICourseService, CourseService>();//calisacaği servisi söyledik
            services.AddScoped<ICourseRepository, EFCourseRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<CourseDbContext>(option => option.UseSqlServer(connectionString));
            return services;
        }
    }
}
