using Microsoft.EntityFrameworkCore;

namespace Authentication.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Userdetail> Users { get; set; }
        public DbSet<user> Interns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().Property(i => i.Id).ValueGeneratedNever();
        }
    }

}
