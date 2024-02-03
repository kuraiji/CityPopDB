using CityPopDB.Data;
using CityPopDB.DTOs;

namespace CityPopDB.Services.VoteService;

public interface IVoteService
{
    Task<string> Post(DataContext context, VotePostDto request);
    Task<List<VoteGetDto>> GetUser(DataContext context, string id);
    Task<List<VoteGetDto>> GetAlbum(DataContext context, int id);
    Task<string> Delete(DataContext context, int id);
    Task<VoteGetDto> Put(DataContext context, VotePutDto request);
}