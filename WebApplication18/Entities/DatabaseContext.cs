using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hayvan> Hayvans { get; set; }
        public DbSet<SahiplendirilmisHayvan> SahiplendirilmisHayvans { get; set; }
    }
}
