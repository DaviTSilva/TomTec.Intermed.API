using System;
using System.Collections.Generic;
using System.Text;

namespace TomTec.Intermed.Models
{
    public class Signature : BaseEntity
    {
        public int HealthProfessionalId { get; set; }
        public HealthProfessional HealthProfessional { get; set; }
        public DateTime Expire { get; set; }
        public bool isPayed { get; set; }
        public bool IsFreeTrial { get; set; }
        public double Value { get; set; }
        public int SignatureTypeId { get; set; }
        public SignatureType SignatureType { get; set; }
    }
}
