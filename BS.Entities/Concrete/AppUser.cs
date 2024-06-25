using BS.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
    public class AppUser :IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string? Adress { get; set; }
        public UserType UserType { get; set; }


        //iliskiler

        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public ShoppingCart? ShoppingCart { get; set; } //1-1 yaptık
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }



    }
}
