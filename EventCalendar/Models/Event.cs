using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalendar.Models
{
    public class Event
    {
        public int Id { get; set; }

        public virtual Vrsta Vrsta { get; set; }
        public int VrstaId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime Datum { get; set; }


        [StringLength(100)]
        public string Napomena { get; set; }

        public virtual Mjesto Mjesto { get; set; }
        public int MjestoId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }
    }
}