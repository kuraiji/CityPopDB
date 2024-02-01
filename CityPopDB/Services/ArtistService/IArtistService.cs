using CityPopDB.Data;
using CityPopDB.DTOs;

namespace CityPopDB.Services.ArtistService;

public interface IArtistService
{
    Task<string> Post(DataContext context, ArtistPostDto request);
    Task<ArtistGetDto> Get(DataContext context, int id);
    Task<List<ArtistGetSomeDto>> GetSome(DataContext context, string? filter, int page, int items, bool isDesc);
    Task<string> Delete(DataContext context, int id);
    Task<ArtistPostDto> Put(DataContext context, ArtistPutDto request);
}