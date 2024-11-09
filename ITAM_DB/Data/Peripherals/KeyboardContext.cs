using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{   
      public class KeyboardContext : DbContext // Inheriting from DbContext
    {
        public KeyboardContext(DbContextOptions<KeyboardContext> options) : base(options) { }

        public DbSet<Keyboard> Keyboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<Keyboard>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<Keyboard>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
