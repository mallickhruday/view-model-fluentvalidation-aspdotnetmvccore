using System;
using System.Text.RegularExpressions;
using FluentValidation;
using SimonGilbert.Blog.ViewModels;

namespace SimonGilbert.Blog.Validation
{
    public class UserAccountViewModelTechDetailsValidator : AbstractValidator<UserAccountViewModel>
    {
        private static Regex ValidEmailRegex = CreateValidEmailRegex();

        public UserAccountViewModelTechDetailsValidator()
        {
            RuleFor(m => m.Username)
                .Must(IsValidUsername)
                .WithMessage("Please specify a username that does not contain special characters.");

            RuleFor(m => m.EmailAddress)
                .Must(IsValidEmailAddress)
                .WithMessage("Please specify a valid email address.");

            RuleFor(m => m.MobilePhoneNumber)
                .Must(IsAValidUKMobilePhoneNumber)
                .WithMessage("Please specify a valid UK mobile phone number.");
        }

        private bool IsValidUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
                return false;

            var specialCharacterPattern = new Regex("^[a-zA-Z0-9 ]*$");

            if (specialCharacterPattern.IsMatch(username))
                return true;

            return false;
        }

        private static Regex CreateValidEmailRegex()
        {
            var validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            return (!String.IsNullOrEmpty(emailAddress)) &&
                ValidEmailRegex.IsMatch(emailAddress);
        }

        private bool IsAValidUKMobilePhoneNumber(string mobilePhoneNumber)
        {
            if (!String.IsNullOrEmpty(mobilePhoneNumber) &&
                mobilePhoneNumber.StartsWith("+44", StringComparison.CurrentCulture) &&
                mobilePhoneNumber.Length == 13)
                return true;

            return false;
        }
    }
}
