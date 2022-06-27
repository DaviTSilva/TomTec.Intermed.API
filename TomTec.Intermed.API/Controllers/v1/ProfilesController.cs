using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs.v1;
using TomTec.Intermed.API.Records.v1;
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
        private readonly IRepository<Claim> _claimRepository;
        private readonly IRepository<UserType> _userTypeRepository;
        private readonly IRepository<Address> _adddressRepository;

        public ProfilesController(IRepository<User> userRepository, IRepository<Claim> claimRepository, IRepository<UserType> userTypeRepository, IRepository<Address> adddressRepository) 
        {
            _userRepository = userRepository;
            _claimRepository = claimRepository;
            _userTypeRepository = userTypeRepository;
            _adddressRepository = adddressRepository;
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
                var users = _userRepository.GetComplete();
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
                var user = _userRepository.GetComplete(id);
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
                var user = _userRepository.GetCompleteUserByUserName(userName);
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
                var user = _userRepository.GetCompleteUserByEmail(email);
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
        [HttpDelete("{id}")]
        public IActionResult CancellUser(int id)
        {
            try
            {
                _userRepository.Cancell(id);
                return Ok(new
                {
                    message = ResponseMessage.Success,
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] UpdateProfileDto dto, int id)
        {
            User user = dto.ToModel();
            PopulateUser(id, user);

            _userRepository.Update(user);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }

        private void PopulateUser(int id, User user)
        {
            user.Id = id;
            user.UsersClaims.ToList().ForEach(uc => uc.Claim = _claimRepository.Get(uc.ClaimId));
            user.UsersClaims.ToList().ForEach(uc => uc.UserId = id);
            user.UserType = _userTypeRepository.Get(user.UserTypeId);
            user.Address = _adddressRepository.Get(user.AddressId);
        }
    }
}
