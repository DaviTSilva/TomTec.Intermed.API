using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomTec.Intermed.Models
{
    public class Specialty : BaseEntity
    {
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Name { get; set; }
    }
}
