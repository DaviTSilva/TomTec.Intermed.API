using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomTec.Intermed.Models
{
    public class Address : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Number { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string AdditionalInformation { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PostalCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string CountryName { get; set; }
    }
}