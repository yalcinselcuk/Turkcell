﻿using AutoMapper;
using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Mvc.Extensions;
using CourseApp.Services;
using CourseApp.Services.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(15);
}
);
var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddInjections(connectionString);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();//migration'da oluşabilecek hataları döndürür

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Users/Login"; 
                    opt.AccessDeniedPath = "/Users/AccessDenied";
                    opt.ReturnUrlParameter = "gidilecekSayfa";
                });

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching(opt =>
{
    opt.SizeLimit = 100000;
});//evrensel cache'tir: doğrudan html çıktısını bellekte tutulması gerektiğini belirtir

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<CourseDbContext>();
context.Database.EnsureCreated();
DbSeeding.SeedDatabase(context);

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
