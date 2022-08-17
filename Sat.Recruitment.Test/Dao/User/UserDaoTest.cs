using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.DAO.User;
using Sat.Recruitment.Test.Models;
using Sat.Recruitment.Test.Models.Mothers;
using Xunit;

namespace Sat.Recruitment.Test.DAO.User
{
    public class UserRepositoryTest : UnitTest1
    {
        private IDAOUser _daoUser;
        private Mock<IUserFactory> _mockFactory = new Mock<IUserFactory>();

        private List<Recruitment.Models.Abstract.User> usersList;
        private NormalUser normalUser = NormalUserMother.Random();
        private PremiumUser premiumUser = PremiumUserMother.Random();
        private string incorrectEmail = RandomString.Generate(5) + "@mail.com";

        public UserRepositoryTest()
        {
            _daoUser = new DAOUser(_mockFactory.Object);
            _daoUser.Seed();
        }

        internal override void SetupMockObjects()
        {
            _mockFactory
              .Setup(f => f.Create(It.IsAny<UserDto>()))
              .Returns(normalUser)
              .Verifiable();

            usersList = new List<Recruitment.Models.Abstract.User>();
            usersList.Add(normalUser);
            usersList.Add(normalUser);
            usersList.Add(normalUser);
        }
 
    }
}
