using AutoMapper;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using System;

namespace Sat.Recruitment.Factory.User
{
    public class UserFactory : IUserFactory
    {
        private readonly IMapper _mapper;

        public UserFactory() { }
        public UserFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Models.Abstract.User Create(UserDto user)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), user.UserType.ToUpper());
            switch (userType)
            {
                case UserType.NORMAL:
                    return _mapper.Map<NormalUser>(user);
                case UserType.PREMIUM:
                    return _mapper.Map<PremiumUser>(user);
                case UserType.SUPERUSER:
                    return _mapper.Map<SuperUser>(user);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
