using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shapping.api.Entities;
using Shapping.api.Models;
using Shapping.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapping.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authentication")]
    public class authenticationController : ControllerBase 
    {
        private readonly IUserService _userService;

        public authenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public User Login([FromBody] UserDto user)
        {
            var User = _userService.Authenticate(user.Username, user.Password);

            return User;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAll();
        }
    }
}
