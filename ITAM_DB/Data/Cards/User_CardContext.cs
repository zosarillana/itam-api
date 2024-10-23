using ITAM_API.Model.Operations;
using ITAM_DB.Model.Cards;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Cards
{ 
        public class User_CardContext : DbContext // Inheriting from DbContext
        {
            public User_CardContext(DbContextOptions<User_CardContext> options) : base(options) { }

            public DbSet<User_Card> User_Cards { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
            {
                // Define `id` as the primary key
                modelBuilder.Entity<User_Card>()
                    .HasKey(i => i.id);

                // Enable auto-increment for the `id` column
                modelBuilder.Entity<User_Card>()
                    .Property(i => i.id)
                    .ValueGeneratedOnAdd();
            }
        }    
}
