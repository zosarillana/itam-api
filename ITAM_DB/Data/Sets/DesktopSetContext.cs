using ITAM_DB.Data.Peripherals;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Sets;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Sets
{
    public class DesktopSetContext : DbContext
    {
        public DesktopSetContext(DbContextOptions<AVRContext> options) : base(options) { }

        public DbSet<DesktopSet> DesktopSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<DesktopSet>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<DesktopSet>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
