using Xunit;
using System;
using System.Collections.Generic;

using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Test.Models.Mothers;
using Sat.Recruitment.Service.Helpers;

namespace Sat.Recruitment.Test.Services.Helpers
{
    public class HasUserTest
    {
        [Fact]
        public void GivenANewUser_WhenValidationIsCall_ShouldReturnTrue()
        {
            var userDto = UserDtoMother.Random();
            var userList = new List<User>() { NormalUserMother.Random() };
            
            Action callingWithAIncorrectValue =
                    () => HasUser.Duplicated(userList, userDto);
        }
        
        [Fact]
        public void GivenAnExistentUser_WhenValidationIsCall_ShouldReturnFalse()
        {
            var userDto = UserDtoMother.Random();
            var userList = new List<User>() { NormalUserMother.FromDto(userDto) };

            Action callingWithAIncorrectValue =
                    () => HasUser.Duplicated(userList, userDto);
        }
    }
}
