

namespace moment3_2.Models
{
    public class Rented
    {  
        public int RentedId { get; set; }

        public bool IsRented { get; set; } = false;

        //Fk cd
        public int CdId { get; set; }
        public Cd? Cd { get; set; }
        //FK user
        public int UserId { get; set; }
        public User? User { get; set; }

        //public List<Cd>? Cds { get; set; }
        public DateTime TimeRented { get; set; } = DateTime.Now;
        public Rented() { }
    }
}
