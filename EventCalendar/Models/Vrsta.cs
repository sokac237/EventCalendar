using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalendar.Models
{
    public class Vrsta
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Vrsta događaja")]
        public string Naziv { get; set; }
    }
}