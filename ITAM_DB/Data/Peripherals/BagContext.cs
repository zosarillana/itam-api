using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{
    public class BagContext : DbContext
    {
        public BagContext(DbContextOptions<BagContext> options) : base(options) { }

        public DbSet<Bag> Bags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<Bag>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<Bag>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
