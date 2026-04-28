using Day8.Models;
using Day8.RepoServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourProject.Models;

namespace Day8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<_DbContext>(op => op.UseSqlServer("Data Source=DESKTOP-I2JPB1P\\SQLEXPRESS;Initial Catalog=Day9;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
            builder.Services.AddScoped<ITrack, TrackRepo>();
            builder.Services.AddScoped<ITrainee, TraineeRepo>();
            builder.Services.AddScoped<ICourse, CourseRepo>();
            builder.Services.AddScoped<ITraineeCourse, TraineeCourseRepo>();
            builder.Services.AddIdentity<Client, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3; 
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<_DbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
