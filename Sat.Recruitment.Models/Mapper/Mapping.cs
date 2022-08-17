using AutoMapper;

using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Models.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserDto, NormalUser>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<UserDto, PremiumUser>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<UserDto, SuperUser>()
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(
                        src => (UserType)Enum.Parse(typeof(UserType), src.UserType.ToUpper())));
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.UserType,
                    opt => opt.MapFrom(
                        src => src.Type.ToString()));
        }
    }
}
