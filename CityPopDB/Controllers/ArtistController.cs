using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Services.ArtistService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityPopDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController(DataContext context, IArtistService artistService) : ControllerBase
    {
        [HttpPost, Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<string>> PostArtist(ArtistPostDto request)
        {
            try
            {
                return Ok(await artistService.Post(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<string>> GetArtist(int id)
        {
            try
            {
                return Ok(await artistService.Get(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{filter}/{items:int}/{isDesc:bool}/{lastName}")]
        public async Task<ActionResult<List<ArtistGetSomeDto>>> GetSomeArtists(string filter, bool isDesc, int items, string lastName)
        {
            try
            {
                return Ok(await artistService.GetSome(context, filter, isDesc, items, lastName));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id:int}"), Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<string>> DeleteArtist(int id)
        {
            try
            {
                return Ok(await artistService.Delete(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut, Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<ArtistPostDto>> PutArtist(ArtistPutDto request)
        {
            try
            {
                return Ok(await artistService.Put(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
