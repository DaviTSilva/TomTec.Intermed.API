using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomTec.Intermed.Models
{
    public class CreditCardInfo : BaseEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Number { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Expire { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string OwnerName { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string CVV { get; set; }

        [Column(TypeName = "varchar(4)")]
        [Required]
        public string FourLastNumbers { get; set; }
    }
}
