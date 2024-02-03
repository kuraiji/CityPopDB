using CityPopDB.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext(options)
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Vote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Vote>(builder =>
        {
            builder.HasIndex(e => new { e.AlbumId, e.UserId}).IsUnique();
        });
    }
}