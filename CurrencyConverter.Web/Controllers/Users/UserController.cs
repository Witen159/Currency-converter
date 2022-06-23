using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using CurrencyConverter.Core.Domains.Users;
using CurrencyConverter.Core.Domains.Users.Services;
using CurrencyConverter.Web.Controllers.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Web.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public UserDto Get(string id)
        {
            var model = _userService.Get(id);

            return new UserDto()
            {
                Id = model.Id,
                Login = model.Login
            };
        }
        
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _userService.GetAll().Select(x => new UserDto
            {
                Id = x.Id,
                Login = x.Login
            });
        }

        [HttpPost]
        public void Create(CreateUserDto model)
        {
            _userService.Create(new User
            {
                Login = model.Login,
                Password = model.Password
            });
        }

        [HttpPut("/{id}")]
        public void Update(string id, UpdateUserDto model)
        {
            _userService.Update(new User
            {
                Id = id,
                Login = model.Login
            });
        }

        [HttpDelete("/{id}")]
        public void Delete(string id)
        {
            _userService.Delete(id);
        }
        
        /// <summary>
        /// Активация пользователя
        /// </summary>
        /// <param name="id"></param>
        [HttpPatch("/{id}/activate")]
        public void SetActive(string id)
        {
            _userService.SerActive(id);
        }
    }
}