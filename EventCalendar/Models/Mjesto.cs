using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalendar.Models
{
    public class Mjesto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Naziv mjesta")]
        public string Naziv { get; set; }
    }
}