using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.Account
{
    public class LoginViewModel
    {
       
        [EmailAddress]
        public string Email { get; set; }

        
        [DataType(DataType.Password)]
   
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }



}
