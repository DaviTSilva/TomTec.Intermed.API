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
    [Route("v1/claims")]
    public class ClaimsController : Controller
    {
        private readonly IRepository<Claim> _claimsRepository;
        private readonly IRepository<User> _userRepository;

        public ClaimsController(IRepository<Claim> uerRoleRepository, IRepository<User> userRepository)
        {
            _claimsRepository = uerRoleRepository;
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public IActionResult CreateClaim([FromBody] ClaimDto dto)
        {
            var claim = _claimsRepository.Create(dto.ToModel());

            return Created(ResponseMessage.Success, claim);
        }

        [HttpGet("")]
        public IActionResult GetClaim()
        {
            var claim = _claimsRepository.GetComplete();

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = claim
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetClaim(int id)
        {
            var claim = _claimsRepository.GetComplete(id);

            return Ok(new
            {
                message = ResponseMessage.Success,
                value = claim,
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClaim([FromBody] ClaimDto dto, int id)
        {
            var claim = dto.ToModel();
            claim.Id = id;

            _claimsRepository.Update(claim);

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

        [HttpPost("sign/{id}")]
        public IActionResult SignClaim([FromBody] SigningClaimDto dto, int id)
        {
            _claimsRepository.SignUserToClaim(dto.UserId, id);
            return Ok(new { 
                message = ResponseMessage.Success
            });
        }

        [HttpPost("unsign/{id}")]
        public IActionResult UnsignClaim([FromBody] SigningClaimDto dto, int id)
        {
            _claimsRepository.UnsignUserToClaim(dto.UserId, id);
            return Ok(new
            {
                message = ResponseMessage.Success
            });
        }
    }
}
