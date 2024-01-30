using Microsoft.AspNetCore.Identity;

namespace CityPopDB.Entities;

public class Vote
{
    public int Id { get; set; }
    public required double Rating { get; set; }
    public required IdentityUser User { get; set; }
    public required Album Album { get; set; }
}