using Sat.Recruitment.DAO.User;
using Sat.Recruitment.Factory.User;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Exceptions;
using Sat.Recruitment.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserFactory _factory;
        private readonly IDAOUser _dao;
        public UserService(IUserFactory factory, IDAOUser dao)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _dao = dao ?? throw new ArgumentNullException(nameof(dao));
        }

        public Models.Abstract.User GetByEmail(string email)
        {
            var user = _dao.GetByEmail(email);

            if (user is null)
                throw new NotFoundException("User not found");

            return user;
        }

        public void Insert(UserDto user)
        {

            var users = _dao.GetAll().ToList();
            if (HasUser.Duplicated(users, user))
                throw new DuplicatedUserException("Error: user duplicated.");

            _dao.Insert(_factory.Create(user));
            
        }

        public List<Models.Abstract.User> GetAll()
        {
            return _dao.GetAll().ToList();
        }

        //Validate errors
        public string ValidateErrors(UserDto user)
        {
            var errors = "";

            if (user.Name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (user.Email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (user.Address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (user.Phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";

            return errors;
        }
    }
}
