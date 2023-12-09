using Microsoft.EntityFrameworkCore;
using SimpleOnlineStore.Domain.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=.;Initial Catalog=SimpleOnlineStore;User Id=sa;Password=1qaz!QAZ;TrustServerCertificate=Yes;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Ali" },
            new User { Id = 2, Name = "Reza" },
            new User { Id = 3, Name = "Simin" },
            new User { Id = 4, Name = "Shima" }
        );
    }
}
