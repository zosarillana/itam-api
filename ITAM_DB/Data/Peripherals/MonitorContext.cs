using Microsoft.EntityFrameworkCore;
using PeripheralMonitor = ITAM_DB.Model.Peripherals.Monitor; // Alias for Monitor to resolve ambiguity

namespace ITAM_DB.Data.Peripherals
{
    public class MonitorContext : DbContext
    {
        public MonitorContext(DbContextOptions<MonitorContext> options) : base(options) { }

        public DbSet<PeripheralMonitor> Monitors { get; set; } // Using alias here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeripheralMonitor>() // Using alias here as well
                .HasKey(i => i.id);

            modelBuilder.Entity<PeripheralMonitor>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();
        }
    }
}
