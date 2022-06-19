using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomTec.Intermed.Models
{
    public class CreditCardInfo : BaseEntity
    {
        public int HealthProfessionalId { get; set; }

        public HealthProfessional HealthProfessional { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Number { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime Expire { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string OwnerName { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Required]
        public string CVV { get; set; }
    }
}
