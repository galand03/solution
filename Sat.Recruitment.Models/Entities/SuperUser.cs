using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Abstract;
using System;

namespace Sat.Recruitment.Models.Entities
{
    public class SuperUser : User
    {
        public SuperUser() { }

        public SuperUser(UserDto user)
        {
            Name = user.Name;
            Email = user.Email;
            Address = user.Address;
            Phone = user.Phone;
            Money = user.Money;
            Type = (UserType)Enum.Parse(typeof(UserType), user.UserType);
            CalculateMoney();
        }

        public override void CalculateMoney()
        {
            if (Money > 100)
                Money += Money * Convert.ToDecimal(0.20);
        }
    }
}
