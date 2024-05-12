using BS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Context
{
	public class BSDbContext : DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer("Data Source=BURAK;Initial Catalog=BookShopDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;");


		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Book>().Property(b => b.BookName).HasMaxLength(25);

			modelBuilder.Entity<Category>().HasData
			   (
				   new Category() { Id = 1, CategoryName = "Novel" },
				   new Category() { Id = 2, CategoryName = "Poetry" },
				   new Category() { Id = 3, CategoryName = "Biography"},
				   new Category() { Id = 4, CategoryName = "Travel"},
				   new Category() { Id = 5, CategoryName = "Cooking"},
				   new Category() { Id = 6, CategoryName = "Science"}

			   );



		}


	}
}
