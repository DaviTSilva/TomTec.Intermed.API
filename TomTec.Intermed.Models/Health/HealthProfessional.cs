using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TomTec.Intermed.Models
{
    public class HealthProfessional : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        [Column(TypeName = "varchar(max)")]
        [Required]
        public string Description { get; set; }

        public int ContactCardId { get; set; }
        public ContactCard ContactCard { get; set; }

        public int ConsultingAddressId { get; set; }
        public Address ConsultingAddress { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public double Rate { get; set; }

        public ICollection<CreditCardInfo> CreditCardInfo { get; set; }
    }
}
