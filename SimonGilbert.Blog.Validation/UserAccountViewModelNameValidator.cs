using FluentValidation;
using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Validation
{
    public class UserAccountViewModelNameValidator : AbstractValidator<UserAccountViewModel>
    {
        public UserAccountViewModelNameValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("Please specify a first name value between 2 and 50 characters.");
        }
    }
}