using AutoFixture;
using Application.Validators;
using Domain.Models;
using FluentAssertions;
using FluentValidation;

namespace Unit.Tests.Validators
{
    public class UserValidatorTests
    {
        private readonly UserValidator _sut;
        public UserValidatorTests()
        {
            _sut = new UserValidator();
        }

        [Fact]
        public async Task Validator_DoesNotThrow_ValidationException_WhenUserIsValid()
        {
            var fixure = new Fixture();
            var user = fixure.Create<User>();

            var func = () => _sut.ValidateAndThrowAsync(user);

            await func.Should().NotThrowAsync();
        }
    }
}