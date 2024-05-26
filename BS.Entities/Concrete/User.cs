using BS.Entities.Abstract;
using BS.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
    public class User : BaseEntity
    {

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public UserType UserType { get; set; }

        //iliskiler


        public IEnumerable<Comment>? Comments { get; set; }


        public IEnumerable<Order>? Orders { get; set; }


        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }


        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        
    }
}
