using System;
using System.Collections.Generic;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Helpers;

namespace Sat.Recruitment.DAO.User
{
    public class DAOUser : IDAOUser
    {
        private List<Models.Abstract.User> _users;
        private readonly IUserFactory _factory;

        public DAOUser() { }

        public DAOUser(IUserFactory factory)
        {
            _factory = factory;
            _users = new List<Models.Abstract.User>();
        }
        public IEnumerable<Models.Abstract.User> GetAll()
        {
            return _users;
        }

        public Models.Abstract.User GetByEmail(string email)
        {
            return _users.Find(user => String.Equals(user.Email, email));
        }

        public void Insert(Models.Abstract.User user)
        {
            _users.Add(user);
        }

        public void Seed()
        {
            var reader = FileReader.ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new UserDto
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString().ToUpper(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };

                _users.Add(_factory.Create(user));
            }
            reader.Close();
        }
    }
}
