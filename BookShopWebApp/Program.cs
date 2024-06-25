
using BS.BLL.Managers.Concrete;
using BS.DAL.Context;
using BS.DAL.Repositories.Concrete;
using BS.DAL.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using System.Reflection;

namespace BookShopWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// DbContext ekleme
			builder.Services.AddDbContext<BSDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));




			//identity ekleme

			//            builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
			//				.AddEntityFrameworkStores<BSDbContext>();

			//			//builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
			//			//             .AddDefaultTokenProviders()
			//			//             .AddEntityFrameworkStores<BSDbContext>();         //NOT: geniþletilmemiþ halinde bunu kullanýyoruz





			// Identity ekleme 
			builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
				.AddEntityFrameworkStores<BSDbContext>()
				.AddDefaultTokenProviders();




			
			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Admin/Account/Login";    // account/login
				options.LogoutPath = "/Admin/Account/Logout";  // account/logout
			});





			// Add services to the container
			builder.Services.AddControllersWithViews();



			// Dependency injection baðlantýlarý tanýmlama
			builder.Services.AddScoped<BookRepo>();
			builder.Services.AddScoped<BookService>();
			builder.Services.AddScoped<BookManager>();

			builder.Services.AddScoped<CategoryRepo>();
			builder.Services.AddScoped<CategoryService>();
			builder.Services.AddScoped<CategoryManager>();

			builder.Services.AddScoped<ShoppingCartRepo>();
			builder.Services.AddScoped<ShoppingCartService>();
			builder.Services.AddScoped<ShoppingCartManager>();

			builder.Services.AddScoped<ShoppingCartBookRepo>();
			builder.Services.AddScoped<ShoppingCartBookService>();
			builder.Services.AddScoped<ShoppingCartBookManager>();


			// Validation ekleme
			builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


			var app = builder.Build();

			// Configure the HTTP request pipeline
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			
			app.UseAuthentication();
			app.UseAuthorization();



			// Rotalar
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

