using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.API.DTOs.v1;
using TomTec.Intermed.Data;
using TomTec.Intermed.Lib.AspNetCore;
using TomTec.Intermed.Lib.Utils;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.Controllers.v1
{
    [Route("v1/auth")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Claim> _claimRepository;
        private readonly JwtService _jwtService;

        public AuthController(IRepository<User> userRepository, IRepository<Claim> claimRepository)
        {
            _userRepository = userRepository;
            _claimRepository = claimRepository;
            _jwtService = new JwtService();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            try
            {
                var user = _userRepository.Get(
                    u => u.Email.Equals(dto.UserNameOrEmail) || u.UserName.Equals(dto.UserNameOrEmail),
                    u => u.UsersClaims
                    ).FirstOrDefault();
                user.UsersClaims.ToList().ForEach(c => c.Claim = _claimRepository.Get(c.ClaimId));


                if (user == null)
                    return BadRequest(new { message = "Invalid Credentials!" });
                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                    return BadRequest(new { message = "Invalid Credentials!" });

                string jwtToken = _jwtService.Generate(user.Id, user.UsersClaims.Select(c => c.ToSecurityClaim()));
                Response.Cookies.Append("token", jwtToken, new CookieOptions
                {
                    HttpOnly = true
                });

                return Ok(new
                {
                    messsage = ResponseMessage.Success
                });
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwtToken = Request.Cookies["token"];
                var token = _jwtService.Verify(jwtToken);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.Get(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("loggout")]
        public IActionResult Loggout()
        {
            Response.Cookies.Delete("token");
            return Ok(new
            {
                message = ResponseMessage.Success
            });

        }
    }
}
