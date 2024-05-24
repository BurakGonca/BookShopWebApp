using BS.BLL.Managers.Concrete;
using BS.DAL.Context;
using BS.DAL.Repositories.Concrete;
using BS.DAL.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookShopWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<BSDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));



            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //dependency injection baglantilari tanimlama

            builder.Services.AddScoped<BookRepo>();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<BookManager>();

            builder.Services.AddScoped<CategoryRepo>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<CategoryManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.MapAreaControllerRoute(
                name: "Admin_area",
                areaName: "Admin",
                pattern: "Admin/{controller=Book}/{action=Index}/{id?}"
            );


            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );


            app.Run();
        }
    }
}
