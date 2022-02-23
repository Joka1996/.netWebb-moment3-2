using System.ComponentModel.DataAnnotations; // required

namespace moment3_2.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Krav på användarnamn.. ")]

        [Display(Name = "Användarnamn:")]
        public string? UserName { get; set; }

        //skiva
        public List<Cd>? Cds { get; set; }

        public User()
        {

        }
    }
}
