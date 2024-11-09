using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{
    public class AVRContext : DbContext
    {
        public AVRContext(DbContextOptions<AVRContext> options) : base(options) { }

        public DbSet<AVR> AVRs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<ExternalDrive>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<ExternalDrive>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}