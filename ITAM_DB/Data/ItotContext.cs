using ITAM_API.Model.Operations;
using ITAM_DB.Controllers.Peripherals;
using ITAM_DB.Data.Peripherals;
using ITAM_DB.Model.Cards;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using ITAM_DB.Model.Sets;
using ITAM_DB.Model.User;
using Microsoft.EntityFrameworkCore;
using PeripheralMonitor = ITAM_DB.Model.Peripherals.Monitor;

namespace ITAM_API.Data
{
    public class ItotContext : DbContext
    {
        public ItotContext(DbContextOptions<ItotContext> options) : base(options) { }

        public DbSet<Itot_Pc> Itot_Pcs { get; set; }
        public DbSet<Itot_Peripheral> Itot_Peripherals { get; set; }
        public DbSet<Pc_Card> Pc_Cards { get; set; }
        public DbSet<User_Card> User_Cards { get; set; }
        public DbSet<AVR> AVRs { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Dongle> Dongles { get; set; }
        public DbSet<ExternalDrive> ExternalDrives { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<LanAdapter> LanAdapters { get; set; }
        public DbSet<PeripheralMonitor> Monitors { get; set; }
        public DbSet<Mouse> Mouses { get; set; }
        public DbSet<UPS> UPSs { get; set; }
        public DbSet<WebCam> WebCams{ get; set; }
        public DbSet<Desktop> Desktops { get; set; }
        public DbSet<DesktopSet> DesktopSets { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopSet> LaptopSets { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Itot_Pc configuration
            modelBuilder.Entity<Itot_Pc>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Itot_Pc>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();

            // Itot_Peripheral configuration
            modelBuilder.Entity<Itot_Peripheral>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Itot_Peripheral>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();

            // Pc_Card configuration
            modelBuilder.Entity<Pc_Card>()
                .HasKey(i => i.id);

            modelBuilder.Entity<Pc_Card>()
               .Property(i => i.id)
               .ValueGeneratedOnAdd();

            // User_Card configuration
            modelBuilder.Entity<User_Card>()
                .HasKey(i => i.id);

            modelBuilder.Entity<User_Card>()
                .Property(i => i.id)
                .ValueGeneratedOnAdd();

            // AVR configuration
            modelBuilder.Entity<AVR>()
                .HasKey(a => a.id);

            modelBuilder.Entity<AVR>()
                .Property(a => a.id)
                .ValueGeneratedOnAdd();

            // Bag configuration
            modelBuilder.Entity<Bag>()
                .HasKey(b => b.id);

            modelBuilder.Entity<Bag>()
                .Property(b => b.id)
                .ValueGeneratedOnAdd();

            // Dongle configuration
            modelBuilder.Entity<Dongle>()
                .HasKey(d => d.id);

            modelBuilder.Entity<Dongle>()
                .Property(d => d.id)
                .ValueGeneratedOnAdd();

            // ExternalDrive configuration
            modelBuilder.Entity<ExternalDrive>()
                .HasKey(e => e.id);

            modelBuilder.Entity<ExternalDrive>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd();

            // Keyboard configuration
            modelBuilder.Entity<Keyboard>()
                .HasKey(k => k.id);

            modelBuilder.Entity<Keyboard>()
                .Property(k => k.id)
                .ValueGeneratedOnAdd();

            // LanAdapter configuration
            modelBuilder.Entity<LanAdapter>()
                .HasKey(l => l.id);

            modelBuilder.Entity<LanAdapter>()
                .Property(l => l.id)
                .ValueGeneratedOnAdd();

            // Monitor configuration
            modelBuilder.Entity<PeripheralMonitor>()
                .HasKey(m => m.id);

            modelBuilder.Entity<PeripheralMonitor>()
                .Property(m => m.id)
                .ValueGeneratedOnAdd();

            // Mouse configuration
            modelBuilder.Entity<Mouse>()
                .HasKey(m => m.id);

            modelBuilder.Entity<Mouse>()
                .Property(m => m.id)
                .ValueGeneratedOnAdd();

            // UPS configuration
            modelBuilder.Entity<UPS>()
                .HasKey(u => u.id);

            modelBuilder.Entity<UPS>()
                .Property(u => u.id)
                .ValueGeneratedOnAdd();

            // WebCamController configuration
            modelBuilder.Entity<WebCam>()
                .HasKey(w => w.id);

            modelBuilder.Entity<WebCam>()
                .Property(w => w.id)
                .ValueGeneratedOnAdd();

            // WebCamController configuration
            modelBuilder.Entity<Desktop>()
                .HasKey(d => d.id);

            modelBuilder.Entity<Desktop>()
                .Property(d => d.id)
                .ValueGeneratedOnAdd();
            
            // WebCamController configuration
            modelBuilder.Entity<DesktopSet>()
                .HasKey(ds => ds.id);

            modelBuilder.Entity<WebCam>()
                .Property(ds => ds.id)
                .ValueGeneratedOnAdd();
            
            // WebCamController configuration
            modelBuilder.Entity<Laptop>()
                .HasKey(l => l.id);

            modelBuilder.Entity<Laptop>()
                .Property(l => l.id)
                .ValueGeneratedOnAdd();
            
            // WebCamController configuration
            modelBuilder.Entity<LaptopSet>()
                .HasKey(ls => ls.id);

            modelBuilder.Entity<WebCam>()
                .Property(ls => ls.id)
                .ValueGeneratedOnAdd();

            // Additional configuration can be added as needed for each entity.
        }
    }
}
