using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class ClaimDto
    {
        public string Name { get; set; }

        public Claim ToModel()
        {
            return new Claim
            {
                Name = this.Name
            };
        }
    }

}
