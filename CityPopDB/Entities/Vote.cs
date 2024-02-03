using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CityPopDB.Entities;

public class Vote
{
    public int Id { get; set; }
    public required double Rating { get; set; }
    [ForeignKey("User")]
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string? UserId { get; set; }
    public required IdentityUser User { get; set; }
    [ForeignKey("Album")]
    public int? AlbumId { get; set; }
    public required Album Album { get; set; }
}