namespace CityPopDB.DTOs;

public record struct UserGetDto(string Username, string Email);
public record struct UserCreateDto(string Username, string Email, string Password);