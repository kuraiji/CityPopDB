using CityPopDB.Common;
using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Services.UserService;

public class UserService : IUserService
{
    public async Task<UserGetDto> Post(DataContext context, UserCreateDto request)
    {
        throw new NotImplementedException();
        /*var newUser = new User
        {
            Username = request.Username,
            Email = request.Email,
            Password = PasswordHasher.HashPassword(request.Password, out var salt),
            Salt = Convert.ToHexString(salt)
        };
        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();
        return new UserGetDto(request.Username, request.Email);*/
    }

    public async Task<UserGetDto> Get(DataContext context, string usernameOrEmail, string password)
    {
        throw new NotImplementedException();
        /* var fetchedUser = await context.Users.FirstAsync(user =>
             user.Username == usernameOrEmail || user.Email == usernameOrEmail);
         if (fetchedUser == null) throw new Exception("Couldn't Find User");
         var isValid = PasswordHasher.VerifyPassword(password,
             fetchedUser.Password,
             Convert.FromHexString(fetchedUser.Salt));
         if (!isValid) throw new Exception("Password is Incorrect");
         return new UserGetDto(fetchedUser.Username, fetchedUser.Email);*/
    }
}