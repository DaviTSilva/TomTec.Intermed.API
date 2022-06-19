using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs.v1;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [Route("v1/user-types")]
    public class UserTypesController : Controller
    {
        private readonly IRepository<UserType> _userTypeRepository;

        public UserTypesController(IRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [HttpPost("")]
        public IActionResult CreateUserType([FromBody] UserTypeDto dto)
        {
            var userType = _userTypeRepository.Create(dto.ToModel());

            return Created(ResponseMessage.Success, userType);
        }

        [HttpGet("")]
        public IActionResult GetUserTypes()
        {
            var userTypes = _userTypeRepository.Get();

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = userTypes,
            }); ;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserType(int id)
        {
            var userType = _userTypeRepository.Get(id);
            return Ok(new
            {
                message = ResponseMessage.Success,
                value = userType
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserType([FromBody] UserTypeDto dto, int id)
        {
            var userType = dto.ToModel();
            userType.Id = id;
            _userTypeRepository.Update(userType);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserType(int id)
        {
            _userTypeRepository.Delete(id);

            return Ok(new
            {
                message = ResponseMessage.Success
            });
        }
    }
}
