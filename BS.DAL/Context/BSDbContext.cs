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

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<User> Users { get; set; }



        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        {

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
