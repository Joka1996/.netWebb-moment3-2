using System.ComponentModel.DataAnnotations; // required

namespace moment3_2.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Krav på användarnamn.. ")]

        [Display(Name = "Användarnamn:")]
        public string? UserName { get; set; }

        //public int?  CdId { get; set; }
        //public Cd? Cd { get; set; }

        //public int CdId { get; set; }
        //public Cd? Cd { get; set; }

        //skiva
        public List<Cd>? Cds { get; set; }
        //rent
        //public List<Rented>? Renteds { get; set; }
        //public int RentedId { get; set; }
        //public Rented? Rented { get; set; }
        public User()
        {

        }
    }
}
