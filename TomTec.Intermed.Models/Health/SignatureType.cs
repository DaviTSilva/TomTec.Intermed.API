﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TomTec.Intermed.Models
{
    public class SignatureType : BaseEntity
    {
        [Column(TypeName = "varchar(150)")]
        [Required]
        public string Name { get; set; }
    }
}
