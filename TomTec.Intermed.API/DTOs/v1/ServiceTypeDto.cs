using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class ServiceTypeDto
    {
        public string Name { get; set; }

        public ServiceType ToModel()
        {
            return new ServiceType()
            {
                Name = this.Name,
            };
        }
    }
}
