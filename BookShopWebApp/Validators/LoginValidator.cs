using BookShopWebApp.Models.Account;
using FluentValidation;

namespace BookShopWebApp.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Email).NotEmpty().WithMessage("Email adresi zorunludur.")
                                         .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");

            RuleFor(login => login.Password).NotEmpty().WithMessage("Şifre zorunludur.")
                                            .MinimumLength(10).WithMessage("Şifreniz en az 10 karakter olmalıdır.")
                                            .Matches("[A-Z]").WithMessage("En az 1 Büyük karakter içermeli")
                                            .Matches("[a-z]").WithMessage("En az 1 Küçük karakter içermeli")
                                            .Matches("[0-9]").WithMessage("En az 1 Rakam içermeli")
                                            .Matches("[^a-zA-Z0-9]").WithMessage("En az 1 özel karakter içermeli");


            //RuleFor(login => login.Password).Password();



        }



    }
}
