using BS.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models
{
    public class UserViewModel
    {

        public int UserId { get; set; }


        public string Name { get; set; }


        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ile şifre tekrarı aynı değildir.")]
        public string ConfirmPassword { get; set; }

        public string? Adress { get; set; }

        public Gender Gender { get; set; }



        //iliskiler


        public IEnumerable<CommentViewModel>? Comments { get; set; }


        public IEnumerable<OrderViewModel>? Orders { get; set; }


        public ShoppingCartViewModel? ShoppingCart { get; set; }


        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }




        //not: sadece shoppingcart açıktı, diğerlerini de açtım order maplemesi için

    }
}
