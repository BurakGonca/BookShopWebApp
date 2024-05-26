using BS.BLL.Managers.Concrete;
using BS.DAL.Context;
using BS.DAL.Repositories.Concrete;
using BS.DAL.Services.Concrete;
using Microsoft.EntityFrameworkCore;

using System;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using FluentValidation;

namespace BookShopWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			//authentication ekleme
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
							.AddCookie(opt =>
							{
								opt.LoginPath = "/Admin/Account/Login";    //accoount/login
								opt.LogoutPath = "/Admin/Account/Logout";  //accoount/logout
							});



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



			//validation ekleme
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            //identity ekleme

            builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
				.AddEntityFrameworkStores<BSDbContext>();

            //builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
            //             .AddDefaultTokenProviders()
            //             .AddEntityFrameworkStores<BSDbContext>();         //NOT: geniþletilmemiþ halinde bunu kullanýyoruz




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




			//authenticationi kullandirmak için ekledik.
			app.UseAuthentication();


			app.UseAuthorization();



            //rotalar

            

            app.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
          );


            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"
			);





			app.Run();
		}
	}











}
