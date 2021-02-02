using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InwiApli.Models
{
    public class Recharge
    {
        public Object _id { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [Required]
        public string tel { get; set; }

        [Required]
        public int montant { get; set; }

        public DateTime date { get; set; }
    }
}