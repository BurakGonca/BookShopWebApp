using BS.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Display(Name = "Adınız")]
        public string Name { get; set; }

        [Display(Name = "Soyadınız")]
        public string Surname { get; set; }

        [EmailAddress]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ile şifre tekrarı aynı değildir.")]
        [Display(Name = "Şifre Tekrarı")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Adresiniz")]
        public string? Adress { get; set; }

        [Display(Name = "Cinsiyetiniz")]
        public Gender Gender { get; set; }



        //iliskiler


        //public IEnumerable<CommentViewModel>? Comments { get; set; }


        //public IEnumerable<OrderViewModel>? Orders { get; set; }


        //public IEnumerable<ShoppingCartViewModel> ShoppingCarts { get; set; }


        //public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }


    }
}
