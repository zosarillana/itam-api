using ITAM_DB.Data.Computers;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Model.Sets;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Sets
{
    public class LaptopSetContext : DbContext
    {
        public LaptopSetContext(DbContextOptions<LaptopSetContext> options) : base(options) { }

        public DbSet<LaptopSet> LaptopSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<LaptopSet>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<LaptopSet>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
