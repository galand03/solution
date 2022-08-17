using System;
using System.Collections.Generic;
using System.Reflection;
using Sat.Recruitment.Models.Entities;

namespace Sat.Recruitment.DAO.User
{
    public interface IDAOUser
    {
        public Models.Abstract.User GetByEmail(string email);
        public IEnumerable<Models.Abstract.User> GetAll();
        public void Insert(Models.Abstract.User user);
        public void Seed();
    }
}
