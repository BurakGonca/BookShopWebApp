﻿using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#.?!@$%^&*-]).{8,}$", ErrorMessage = "Şifreniz en az 8 karakter en fazla 10 karakter olmalıdır. İçinde sayı ve karakter içermelidir.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }



}
