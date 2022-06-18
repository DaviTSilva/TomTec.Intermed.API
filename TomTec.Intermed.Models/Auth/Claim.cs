using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TomTec.Intermed.Models
{
    public class Claim : BaseEntity
    {
        [Column(TypeName = "varchar(200)")]
        [Required]
        public string Name { get; set; }

        public ICollection<UsersClaims> UsersClaims { get; set; }
    }
}
