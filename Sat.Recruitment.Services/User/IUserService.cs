using System;
using Sat.Recruitment.Models.Entities;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Models.Dtos;

namespace Sat.Recruitment.Services.User
{
    public interface IUserService
    {
        public Models.Abstract.User GetByEmail(string email);
        public List<Models.Abstract.User> GetAll();
        public void Insert(UserDto user);
        public string ValidateErrors(UserDto user);
    }
}
