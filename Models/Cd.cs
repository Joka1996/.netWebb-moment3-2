using System.ComponentModel.DataAnnotations; // required
using System.Collections.Generic;

namespace moment3_2.Models
{
    public class Cd
    {
        public int CdId { get; set; }
        [Display(Name ="Album:")]
        [Required(ErrorMessage ="Krav för ett namn på albumet.. ")]
        public string? Album_Name { get; set; }
        [Display(Name = "Uthyrd?")]
        public bool IsRented { get; set; } = false;

        [Display(Name = "Tiden CD:n hyrdes ut:")]
        public DateTime? TimeRented { get; set; } = null;
        //navigation
        [Display(Name ="Artist:")]
        public int? ArtistId { get; set; }

        public Artist? Artist { get; set; }

        [Display(Name = "Användare som hyr:")]
        public int? UserId { get; set; } = null; //låter mig inte välja noll
        [Display(Name = "Användare som hyr:")]
        public User? User { get; set; } = null;

        //public int? RentedId { get; set; }

        //public Rented? Rented { get; set; }


        //public List<Rented>? Renteds { get; set; }
        public Cd() { }
    }
}
