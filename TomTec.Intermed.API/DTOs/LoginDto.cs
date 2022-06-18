using System;
using System.Collections.Generic;
using System.Text;

namespace TomTec.Intermed.API.DTOs
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
