using CityPopDB.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Data;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext(options)
{
    //public DbSet<User> Users { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Vote> Votes { get; set; }
}