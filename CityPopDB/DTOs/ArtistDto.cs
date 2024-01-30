using CityPopDB.Entities;

namespace CityPopDB.DTOs;

public record struct ArtistPostDto(string Name, string? ImageLink);
public record struct ArtistGetDto(string Name, string? ImageLink, List<Album> Albums);
public record struct ArtistGetSomeDto(string Name);
public record struct ArtistPutDto(int Id, string Name, string? ImageLink);