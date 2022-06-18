using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.AspNetCore.Filters;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Authorization]
    [Route("v1/claims")]
    public class ClaimsController : Controller
    {
        private readonly IRepository<Claim> _claimsRepository;

        public ClaimsController(IRepository<Claim> uerRoleRepository)
        {
            _claimsRepository = uerRoleRepository;
        }

        [HttpPost("")]
        public IActionResult CreateClaim([FromBody] ClaimDto dto)
        {
            var userClaim = _claimsRepository.Create(dto.ToModel());

            return Created(ResponseMessage.Success, userClaim);
        }

        [HttpGet("")]
        public IActionResult GetClaim()
        {
            var userClaims = _claimsRepository.Get();

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = userClaims
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetClaim(int id)
        {
            var userClaim = _claimsRepository.Get(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = userClaim,
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClaim([FromBody] ClaimDto dto, int id)
        {
            var userClaim = dto.ToModel();
            userClaim.Id = id;
            _claimsRepository.Update(dto.ToModel());

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClaim(int id)
        {
            _claimsRepository.Delete(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
            });
        }
    }
}
