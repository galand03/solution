using Moq;
using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Test.Models;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Services.User;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.DAO.User;
using Sat.Recruitment.Models.Exceptions;
using Sat.Recruitment.Test.Models.Mothers;

namespace Sat.Recruitment.Test.Services
{
    public class UserServiceTest : UnitTest1
    {
        private IUserService services;
        private Mock<IUserFactory> _mockFactory = new Mock<IUserFactory>();
        private Mock<IDAOUser> _mockDao = new Mock<IDAOUser>();

        private UserDto userDto = UserDtoMother.Random();
        private NormalUser normalUser = NormalUserMother.Random();
        private List<NormalUser> userList = new List<NormalUser>() { NormalUserMother.Random() };

        private string email = RandomString.Generate(5) + "@mail.com";
        private string incorrectEmail = RandomString.Generate(5) + "@mail.com";

        public UserServiceTest()
        {
            services = new UserService(_mockFactory.Object, _mockDao.Object);
        }

        internal override void SetupMockObjects()
        {
            _mockFactory
                .Setup(f => f.Create(userDto))
                .Returns(normalUser)
                .Verifiable();

            _mockDao
                .Setup(r => r.GetByEmail(email))
                .Returns(normalUser)
                .Verifiable();

            _mockDao
                .Setup(r => r.GetByEmail(incorrectEmail))
                .Returns<NormalUser>(null)
                .Verifiable();

            _mockDao
                .Setup(r => r.GetAll())
                .Returns(userList)
                .Verifiable();

            _mockDao
                .Setup(r => r.Insert(normalUser))
                .Verifiable();
        }
    }
}
