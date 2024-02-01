using CityPopDB.Data;
using CityPopDB.DTOs;

namespace CityPopDB.Services.AlbumService;

public interface IAlbumService
{
    Task<string> Post(DataContext context, AlbumPostDto request);
    Task<AlbumGetDto> Get(DataContext context, int id);
    Task<List<AlbumGetSomeDto>> GetSome(DataContext context, string? filter, int page, int items, bool isDesc);
    Task<string> Delete(DataContext context, int id);
    Task<AlbumPutOutDto> Put(DataContext context, AlbumPutDto request);
}