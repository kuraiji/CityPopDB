using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
}