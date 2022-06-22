using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TomTec.Intermed.Models;

namespace TomTec.Intermed.API.DTOs.v1
{
    public class UpdateHealthProfessionalDto
    {
        public int UserId { get; set; }
        public int ServiceTypeId { get; set; }
        public int SpecialtyId { get; set; }
        public string Description { get; set; }
        public int ConsultingAddressId { get; set; }
        public int ContactCardId { get; set; }
        public int CreditCardInfoId { get; set; }
        public double Rate { get; set; }

        public HealthProfessional toModel()
        {

            var model = new HealthProfessional()
            {
                UserId = this.UserId,
                ServiceTypeId = this.ServiceTypeId,
                Description = this.Description,
                ContactCardId = this.ContactCardId,
                ConsultingAddressId = this.ConsultingAddressId,
                CreditCardInfoId = this.CreditCardInfoId,
                Rate = this.Rate,
            };

            return model;
        }
    }
}
