using System.ComponentModel.DataAnnotations;

namespace CityPopDB.Entities;

public class Album
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(100)]
    public string? ImageLink { get; set; }
    public required List<string> Tracks { get; set; }
    public required Artist AlbumArtist { get; set; }
    public List<Vote>? Votes { get; set; }
}