using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs;
using TomTec.Intermed.API.Records;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Route("v1/profiles")]
    public class ProfilesController : Controller
    {
        private readonly IRepository<User> _userRepository;
        public ProfilesController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            var user = _userRepository.Create(dto.ToModel());
            return Created(ResponseMessage.Success, new UserRegisterRecord(user));
        }

        [Authorization]
        [HttpGet("")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userRepository.Get(u => u.Address,
                    u => u.UsersClaims,
                    u => u.UserType);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = new UserListRecord(users)
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _userRepository.Get(id, u => u.Address,
                    u => u.UsersClaims,
                    u => u.UserType);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("username/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                var user = _userRepository.Get(u => u.UserName.Equals(userName), u => u.Address,
                    u => u.UsersClaims,
                    u => u.UserType);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorization]
        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = _userRepository.Get(u => u.Email.Equals(email), u => u.Address,
                    u => u.UsersClaims,
                    u => u.UserType);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                    value = user
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] UserRegisterDto dto, int id)
        {
            User user = dto.ToModel();
            user.Id = id;
            _userRepository.Update(user);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
