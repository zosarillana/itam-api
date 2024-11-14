using ITAM_DB.Model.Sets;
using Microsoft.EntityFrameworkCore;
using UserModel = ITAM_DB.Model.User.User;

namespace ITAM_DB.Data.User
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define `id` as the primary key for LaptopSet
            modelBuilder.Entity<LaptopSet>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<LaptopSet>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
