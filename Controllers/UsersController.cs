using System.Collections.Generic;
using FirstMediatR.Model;
using FirstMediatR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstMediatR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        } 

        [HttpGet("{email}")]
        public User Get(string email)
        {
            var user = _userService.Get(email);
            return user;
        }
    }
}