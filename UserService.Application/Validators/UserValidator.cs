using Domain.Models;
using FluentValidation;

namespace Application.Validators
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty();

            RuleFor(user => user.LastName)
                .NotEmpty();
        }
    }
}
