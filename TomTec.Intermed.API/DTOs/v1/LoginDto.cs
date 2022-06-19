using System;
using System.Collections.Generic;
using System.Text;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
