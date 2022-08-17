using Xunit;
using AutoMapper;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Test.Models.Mothers;
using Sat.Recruitment.Models.Mapper;

namespace Sat.Recruitment.Test.Factory.User
{
    public class UserFactoryTest : UnitTest1
    {
        private const string NORMAL_TYPE = "Normal";
        private const string PREMIUM_TYPE = "Premium";
        private const string SUPERUSER_TYPE = "SuperUser";

        private IMapper mapper;
        private IUserFactory factory;
        private MapperConfiguration mockMapper;

        public UserFactoryTest()
        {
            factory = new UserFactory(mapper);
        }

        internal override void SetupMockObjects()
        {
            mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping());
            });
            mapper = mockMapper.CreateMapper();
        }
    }
}
