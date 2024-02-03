using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Services.VoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityPopDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController(DataContext context, IVoteService voteService) : ControllerBase
    {
        [HttpPost, Authorize]
        public async Task<ActionResult<string>> PostVote(VotePostDto request)
        {
            try
            {
                return Ok(await voteService.Post(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
        
        [HttpGet("/User")]
        public async Task<ActionResult<List<VoteGetDto>>> GetUserVotes(string id)
        {
            try
            {
                return Ok(await voteService.GetUser(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
        
        [HttpGet("/Album/{id:int}")]
        public async Task<ActionResult<List<VoteGetDto>>> GetAlbumVotes(int id)
        {
            try
            {
                return Ok(await voteService.GetAlbum(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<ActionResult<string>> DeleteVote(int id)
        {
            try
            {
                return Ok(await voteService.Delete(context, id));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<VoteGetDto>> PutVote(VotePutDto request)
        {
            try
            {
                return Ok(await voteService.Put(context, request));
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
