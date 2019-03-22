using SimonGilbert.Blog.ViewModels;
using SimonGilbert.Blog.Validation;
using Xunit;

namespace SimonGilbert.Blog.Tests
{
    public class UserAccountValidatorTests
    {
        [Fact]
        public void User_Account_Is_Valid()
        {
            var expectedIsValid = true;

            var viewModel = new UserAccountViewModel
            {
                FirstName = "Simon",
                Username = "simongilbert",
                EmailAddress = "hello@simongilbert.net",
                MobilePhoneNumber = "+447890123456",
            };

            var validator = new UserAccountValidator();

            var validationResult = validator.Validate(viewModel);

            Assert.Equal(expectedIsValid, validationResult.IsValid);
        }

        [Fact]
        public void User_Account_Is_Not_Valid()
        {
            var expectedIsValid = false;

            var viewModel = new UserAccountViewModel
            {
                FirstName = "",
                Username = "@simon-gilbert_!?",
                EmailAddress = "hello_simongilbert.net",
                MobilePhoneNumber = "07890123456",
            };

            var validator = new UserAccountValidator();

            var validationResult = validator.Validate(viewModel);

            Assert.Equal(expectedIsValid, validationResult.IsValid);
        }
    }
}
