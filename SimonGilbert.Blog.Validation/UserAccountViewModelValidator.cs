using FluentValidation;
using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Validation
{
    public class UserAccountViewModelValidator : AbstractValidator<UserAccountViewModel>
    {
        public UserAccountViewModelValidator()
        {
            Include(new UserAccountViewModelNameValidator());
            Include(new UserAccountViewModelTechDetailsValidator());
        }
    }
}