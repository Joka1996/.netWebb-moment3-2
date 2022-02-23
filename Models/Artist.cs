using System.ComponentModel.DataAnnotations; // required

namespace moment3_2.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Krav för namn på artist.. ")]
        [Display(Name = "Artist:")]
        public string? ArtistName { get; set; }

        //navigation
        public List<Cd>? Cds { get; set; }

        public Artist()
        {

        }
    }
}
