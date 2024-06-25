using BS.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DAL.Context
{
    public class BSDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        


        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            int userId = 1;
            int roleId = 1;

            //User sees Data
            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(
                    new AppUser
                    {
                        Id = userId,
                        Name = "Admin",
                        Surname = "Admin",
                        Gender = Enums.Gender.Belirtilmedi,
                        UserType = Enums.UserType.Admin,
                        UserName = "Admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        PasswordHash = hasher.HashPassword(null, "12345*Abcde")
                    }
                );

            //Role seed Data
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                    new IdentityRole<int>
                    {
                        Id = roleId,
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    }
                );

            //modelBuilder.Entity<IdentityRole<int>>().HasData(
            //       new IdentityRole<int>
            //       {
            //           Id = 2,
            //           Name = "Customer",
            //           NormalizedName = "Customer".ToUpper()
            //       }
            //   );

            //UserRole seed Data

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                    new IdentityUserRole<int>
                    {
                        UserId = userId,
                        RoleId = roleId
                    }
                );



        }
    }
}