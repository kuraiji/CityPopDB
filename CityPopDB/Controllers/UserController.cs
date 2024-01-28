using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace CityPopDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public UserController(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserGetDto>> CreateUser(UserCreateDto request)
        {
            try
            {
                return Ok(await _userService.Post(_context, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserGetDto>> LogInUser(string usernameOrEmail, string password)
        {
            try
            {
                return Ok(await _userService.Get(_context, usernameOrEmail, password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
