using APIDemo.Models;
using FluentValidation;

namespace APIDemo.Validation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(UserModel => UserModel.UserName).
                NotEmpty().
                WithMessage("User Name Can't Be Empty");

            RuleFor(UserModel => UserModel.Password).
                NotEmpty().
                WithMessage("Password Name Can't Be Empty")
                .Length(5, 14).
                WithMessage("Password Length Must Be 5 to 14 Character")
                .Matches("@\"^[a-zA-Z-']*$\"");

            RuleFor(UserModel => UserModel.ConfirmPassword).
                NotEmpty().
                WithMessage("Confirm Passeord Can't Be Empty")
                .Matches(UserModel => UserModel.Password);

            RuleFor(UserModel => UserModel.Email)
                .NotNull()
                .WithMessage("Email Can't Be Null")
                .EmailAddress()
                .WithMessage("Enter Valid Email Address");

            RuleFor(UserModel => UserModel.Height)
                .InclusiveBetween(105, 214)
                .WithMessage("Enter Valid Height");
        }
    }
}
