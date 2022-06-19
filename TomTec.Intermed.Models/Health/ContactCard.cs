using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomTec.Intermed.Models
{
    public class ContactCard : BaseEntity
    {
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Link { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string CelphoneNumber { get; set; }
    }
}
