using DmlStarterkit.Application.Features.Auth.Queries;
using FluentValidation.TestHelper;
using Xunit;

namespace DmlStarterkit.Tests.Features.Auth
{
    public class GetLoginQueryValidatorTests
    {
        private readonly GetLoginQueryValidator _validator;

        public GetLoginQueryValidatorTests()
        {
            _validator = new GetLoginQueryValidator();
        }

        [Fact]
        public void Should_Pass_When_Email_Is_Valid()
        {
            // Arrange
            var query = new GetLoginQuery
            {
                Email = "test@example.com",
                Password = "ValidPassword123!"
            };

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Theory]
        [InlineData("testexample.com")]
        [InlineData("test@")]
        [InlineData("userdomain..com")]
        public void Should_Not_Pass_When_Email_Is_Invalid(string invalidEmail)
        {
            // Arrange
            var query = new GetLoginQuery
            {
                Email = invalidEmail,
                Password = "ValidPassword123!"
            };

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }


        [Fact]
        public void Should_Pass_When_Email_Is_CaseInsensitive()
        {
            // Arrange
            var query = new GetLoginQuery
            {
                Email = "Test@Example.COM",
                Password = "ValidPassword123!"
            };

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}
