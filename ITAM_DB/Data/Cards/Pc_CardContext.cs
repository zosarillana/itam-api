using ITAM_DB.Model.Cards;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Cards
{
    public class Pc_CardContext : DbContext // Inheriting from DbContext
        {
            public Pc_CardContext(DbContextOptions<Pc_CardContext> options) : base(options) { }

            public DbSet<Pc_Card> Pc_Cards { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
            {
                // Define `id` as the primary key
                modelBuilder.Entity<Pc_Card>()
                    .HasKey(i => i.id);

                // Enable auto-increment for the `id` column
                modelBuilder.Entity<Pc_Card>()
                    .Property(i => i.id)
                    .ValueGeneratedOnAdd();
            }
        }    
}
