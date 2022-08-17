using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Entities;

namespace Sat.Recruitment.Test.Models.Mothers
{
    public static class PremiumUserMother
    {
        public static PremiumUser Random()
        {
            Random rnd = new Random();
            return new PremiumUser()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = rnd.Next(100, 200),
                Type = UserType.PREMIUM
            };
        }

        public static PremiumUser FromDto(UserDto user)
        {
            return new PremiumUser()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Type = UserType.PREMIUM,
                Money = user.Money,
            };
        }

        public static PremiumUser WithMoney(int money)
        {
            Random rnd = new Random();
            return new PremiumUser()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = money,
                Type = UserType.PREMIUM
            };
        }
    }
}
