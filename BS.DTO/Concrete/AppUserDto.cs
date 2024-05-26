using BS.DTO.Abstract;
using BS.Entities.Concrete;
using BS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DTO.Concrete
{
    public class AppUserDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Adress { get; set; }
        public UserType UserType { get; set; }


        //iliskiler

        public IEnumerable<CommentDto>? Comments { get; set; }
        public IEnumerable<OrderDto>? Orders { get; set; }
        public IEnumerable<ShoppingCartDto>? ShoppingCarts { get; set; }
        public IEnumerable<OrderDetailDto>? OrderDetails { get; set; }

    }
}
