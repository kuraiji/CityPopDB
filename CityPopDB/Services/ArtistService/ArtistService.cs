using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<List<ArtistGetSomeDto>> GetSome(DataContext context, string filter, bool isDesc, int items, string lastName)
    {
        
        
        var artists = from artist in context.Artists.Include(artist => artist.Albums)
                                                select new ArtistGetSomeDto
                                                {
                                                    Name = artist.Name
                                                };
        artists = isDesc ? 
            artists.OrderByDescending(a => a.Name) : 
            artists.OrderBy(a => a.Name);


        if (!string.IsNullOrWhiteSpace(filter)) artists = artists.Where(a => a.Name.Contains(filter));
        if (!string.IsNullOrWhiteSpace(lastName))
            artists = artists.Where(a => isDesc ? 
                string.Compare(a.Name, lastName, StringComparison.Ordinal) < 0 : 
                string.Compare(a.Name, lastName, StringComparison.Ordinal) > 0);
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