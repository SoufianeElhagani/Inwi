using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InwiApli.Models
{
    public class NumeroMontant
    {
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [Required]
        public string tel { get; set; }

        [Required]
        public int montant { get; set; }
    }
}