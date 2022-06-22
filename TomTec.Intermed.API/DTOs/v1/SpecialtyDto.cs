using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class SpecialtyDto
    {
        public string Name { get; set; }

        public Specialty ToModel()
        {
            return new Specialty() 
            {
                Name = this.Name,
            };
        }
    }
}
