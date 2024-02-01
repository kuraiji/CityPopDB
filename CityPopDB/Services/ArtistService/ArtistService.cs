using System.Diagnostics.CodeAnalysis;
using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Services.ArtistService;

public class ArtistService : IArtistService
{
    public async Task<string> Post(DataContext context, ArtistPostDto request)
    {
        await context.Artists.AddAsync(new Artist
        {
            Name = request.Name,
            ImageLink = request.ImageLink
        });
        await context.SaveChangesAsync();
        return $"{request.Name} was successfully added";
    }

    public async Task<ArtistGetDto> Get(DataContext context, int id)
    {
        var artist = await context.Artists.Include(artist => artist.Albums).FirstOrDefaultAsync(artist => artist.Id == id);
        if (artist == null) throw new Exception("Artist Not Found");
        return new ArtistGetDto
        {
            Name = artist.Name,
            ImageLink = artist.ImageLink,
            Albums = artist.Albums ?? []
        };
    }

    [SuppressMessage("ReSharper", "CA1862")]
    public async Task<List<ArtistGetSomeDto>> GetSome(DataContext context, string? filter, int page = 0, int items = 50, bool isDesc = false)
    {
        
        //var artists = from artist in context.Artists.Include(artist => artist.Albums)
        var artists = from artist in context.Artists
                                                select new ArtistGetSomeDto
                                                {
                                                    Name = artist.Name
                                                };
        artists = isDesc ? 
            artists.OrderByDescending(a => a.Name) : 
            artists.OrderBy(a => a.Name);
        if (!string.IsNullOrWhiteSpace(filter)) 
            artists = artists.Where(a => a.Name.ToLower().Contains(filter.ToLower()));
        artists = artists.Skip(items * int.Max(page, 0));
        artists = artists.Take(int.Min(items, 50));
        return await artists.ToListAsync();
    }

    public async Task<string> Delete(DataContext context, int id)
    {
        var artist = await context.Artists.FindAsync(id);
        if (artist == null) throw new Exception("Artist not Found");
        var name = artist.Name;
        context.Artists.Remove(artist);
        await context.SaveChangesAsync();
        return $"{name} was removed successfully";
    }

    public async Task<ArtistPostDto> Put(DataContext context, ArtistPutDto request)
    {
        var artist = await context.Artists.FindAsync(request.Id);
        if (artist == null) throw new Exception("Artist not Found");
        artist.Name = request.Name;
        artist.ImageLink = request.ImageLink;
        await context.SaveChangesAsync();
        return new ArtistPostDto
        {
            Name = artist.Name,
            ImageLink = artist.ImageLink
        };
    }
}