using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Services.AlbumService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityPopDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController(DataContext context, IAlbumService albumService) : ControllerBase
    {
        [HttpPost, Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<string>> PostAlbum(AlbumPostDto request)
        {
            try
            {
                return Ok(await albumService.Post(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlbumGetDto>> GetAlbum(int id)
        {
            try
            {
                return Ok(await albumService.Get(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet("{filter}/{items:int}/{isDesc:bool}/{page:int}")]
        public async Task<ActionResult<List<AlbumGetSomeDto>>> GetSomeAlbums(string filter = " ",
            bool isDesc = false,
            int items = 50,
            int page = 0
        )
        {
            try
            {
                return Ok(await albumService.GetSome(context, filter, page, items, isDesc));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id:int}"), Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<string>> DeleteAlbum(int id)
        {
            try
            {
                return Ok(await albumService.Delete(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut, Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<AlbumPutOutDto>> PutArtist(AlbumPutDto request)
        {
            try
            {
                return Ok(await albumService.Put(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
