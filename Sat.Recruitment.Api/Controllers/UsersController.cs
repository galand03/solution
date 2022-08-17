using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;
using Sat.Recruitment.Models.Entities;
using Sat.Recruitment.Models.Exceptions;
using Sat.Recruitment.Models.Helpers;
using Sat.Recruitment.Services.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly List<User> _users = new List<User>();

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser([FromBody] UserDto user)
        {

            try
            {
                var errors = "";
                errors = _userService.ValidateErrors(user);

                if (errors != null && errors != "")
                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = errors
                    };

                _userService.Insert(user);
            }
            catch (DuplicatedUserException e)
            {
                Debug.WriteLine(e.Message);
                return new Result()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            return new Result()
            {
                IsSuccess = true,
                Errors = "User Created"
            };

        }

        [HttpGet("/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                EmailValidator.ValidateEmail(email);
                return Ok(_mapper.Map<UserDto>(_userService.GetByEmail(email)));
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 404;
                return result;
            }
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_mapper.Map<List<UserDto>>(_userService.GetAll()));
            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = 500;
                return result;
            }
        }

    }

}
