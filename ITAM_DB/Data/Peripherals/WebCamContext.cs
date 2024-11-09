using ITAM_API.Model.Operations;
using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Peripherals
{
    public class WebCamContext : DbContext // Inheriting from DbContext
    {
        public WebCamContext(DbContextOptions<WebCamContext> options) : base(options) { }

        public DbSet<WebCam> WebCams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
        {
            // Define `id` as the primary key
            modelBuilder.Entity<WebCam>()
                .HasKey(i => i.id);

            // Enable auto-increment for the `id` column
            modelBuilder.Entity<WebCam>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
