using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class ContactCardDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Link { get; set; }
        public string CelphoneNumber { get; set; }

        public ContactCard ToModel()
        {
            return new ContactCard() 
            { 
                Email = this.Email,
                Phone = this.Phone,
                Link = this.Link,
                CelphoneNumber = this.CelphoneNumber,
            };
        }
    }
}
