using Microsoft.EntityFrameworkCore;
using ChamadoSystemBackend.Models;

namespace ChamadoSystemBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users"); 
            modelBuilder.Entity<Ticket>().ToTable("Tickets"); 

    

            base.OnModelCreating(modelBuilder);
        }

    }
}
