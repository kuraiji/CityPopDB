using CityPopDB.Data;
using CityPopDB.DTOs;

namespace CityPopDB.Services.UserService;

public interface IUserService
{
    Task<UserGetDto> Post(DataContext context, UserCreateDto request);
    Task<UserGetDto> Get(DataContext context, string usernameOrEmail, string password);
}