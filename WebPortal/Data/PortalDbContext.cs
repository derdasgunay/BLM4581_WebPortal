using Microsoft.EntityFrameworkCore;
using WebPortal.Models;

namespace WebPortal.Data;

public class PortalDbContext : DbContext
{
public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Event> Events { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Teknoloji" },
            new Category { Id = 2, Name = "Kariyer" },
            new Category { Id = 3, Name = "Kültür ve Sanat" },
            new Category { Id = 4, Name = "Spor" }
        );
    }
}

