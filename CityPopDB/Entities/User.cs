using System.ComponentModel.DataAnnotations;

namespace CityPopDB.Entities;

public class User
{
    public int Id { get; set; }
    [MaxLength(25)]
    public required string Username { get; set; }
    [MaxLength(40)]
    public required string Email { get; set; }
    [MaxLength(175)]
    public required string Password { get; set; }
    [MaxLength(25)]
    public required string Salt { get; set; }
    public bool IsAdmin { get; set; }
    public List<Vote>? Votes { get; set; }
}