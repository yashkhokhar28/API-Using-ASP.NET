

using APIDemo.Models;
using FluentValidation;

namespace APIDemo.Validation
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(PersonModel => PersonModel.Name)
                .NotNull()
                .WithMessage("Name Can't Be Null")
                .NotEmpty()
                .WithMessage("Name Can't Be Empty");

            RuleFor(PersonModel => PersonModel.Email)
                .NotNull()
                .WithMessage("Email Can't Be Null")
                .EmailAddress()
                .WithMessage("Enter Valid Email Address");

            RuleFor(PersonModel => PersonModel.Contact)
                .NotNull()
                .WithMessage("Enter Contact Number")
                .Length(10);
        }
    }
}
