using System.ComponentModel.DataAnnotations;

namespace CityPopDB.Entities;

public class Artist
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(100)]
    public string? ImageLink { get; set; }
    public List<Album>? Albums { get; set; }
}