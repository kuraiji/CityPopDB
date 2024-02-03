namespace CityPopDB.DTOs;

public record struct AlbumPostDto(string Name, int ArtistId, List<string> Tracks, string? ImageLink);
public record struct AlbumGetDto(string Name, List<string> Tracks, string? ImageLink);
public record struct AlbumGetSomeDto(string AlbumName, string ArtistName, string? ImageLink);
public record struct AlbumPutDto(int Id, string Name, int ArtistId, List<string> Tracks, string? ImageLink);
public record struct AlbumPutOutDto(string Name, string ArtistName, List<string> Tracks, string? ImageLink);