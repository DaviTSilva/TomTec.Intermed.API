using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class SignatureDto
    {
        public int HealthProfessionalId { get; set; }
        public int SignatureTypeId { get; set; }
        public bool isYearlyPack { get; set; }
    }
}
