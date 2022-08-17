using Xunit;
using System;
//using FluentAssertions;

using Sat.Recruitment.Models.Helpers;

namespace Sat.Recruitment.Test.Models.Helpers
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("email@mail.com")]
        public void GivenACorrectEmail_WhenEmailValidatorIsCall_ShouldPass(string email)
        {
            Action callingWithAIncorrectValue =
                () => EmailValidator.ValidateEmail(email);
        }

        [Theory]
        [InlineData("email.com")]
        public void GivenAIncorrectEmail_WhenEmailValidatorIsCall_ShouldThrownEmailException(string email)
        {
            Action callingWithAIncorrectValue =
                () => EmailValidator.ValidateEmail(email);
        }
    }
}
