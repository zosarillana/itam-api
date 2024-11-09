using ITAM_DB.Data.Peripherals;
using ITAM_DB.Model.Computers;
using ITAM_DB.Model.Peripherals;
using Microsoft.EntityFrameworkCore;

namespace ITAM_DB.Data.Computers
{
    public class LaptopContext : DbContext
    {
    //    public LaptopContext(DbContextOptions<LaptopContext> options) : base(options) { }

    //    public DbSet<Laptop> Laptops { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder) // OnModelCreating is the correct method
    //    {
    //        // Define `id` as the primary key
    //        modelBuilder.Entity<Laptop>()
    //            .HasKey(i => i.id);

    //        // Enable auto-increment for the `id` column
    //        modelBuilder.Entity<Laptop>()
    //            .Property(i => i.id)
    //            .ValueGeneratedOnAdd();
        //}
    }
}
