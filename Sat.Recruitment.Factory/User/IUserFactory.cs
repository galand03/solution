using Sat.Recruitment.Models;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Factory.User
{
    public interface IUserFactory
    {
        public Models.Abstract.User Create(UserDto user);
    }
}
