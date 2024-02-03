namespace CityPopDB.DTOs;

public record struct VotePostDto(string UserId, int AlbumId, double Rating);
public record struct VoteGetDto(string UserName, string AlbumName, double Rating);
public record struct VotePutDto(string UserId, int AlbumId, double Rating);
public record struct VoteDeleteDto(string UserId, int AlbumId);