using Microsoft.EntityFrameworkCore;
using moment3_2.Models;

namespace moment3_2.Data
{
    public class CollectionContext : DbContext
    {
        //constructor mejd inställningar
        public CollectionContext(DbContextOptions<CollectionContext> options) : base(options)
        {

        }

        //vilka tabeller ska databasen innehålla
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Cd> Cd { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rented> Rented { get; set; }
    }
}
