using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using StudentManagementSystem.Models;
using System.Configuration;

namespace StudentManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         

            // Add services to the container.
            builder.Services.AddRazorPages();


            builder.Services.AddDbContext<PRN221_StudentManagementSystemContext>();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            //    options.Cookie.HttpOnly = true;
            //    options.AccessDeniedPath = "/Forbidden";
            //    options.LogoutPath = "/Logout";
            //    options.LoginPath = "/Login";
            //});
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            //{
            //    options.LoginPath = "/Login"; // Đường dẫn đến trang đăng nhập
            //    options.ReturnUrlParameter = "returnUrl";
            //}).AddCookie("Admin", options =>
            //{
            //    options.LoginPath = new PathString("/Login");
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.MapRazorPages();

            app.Run();
        }
    }
}