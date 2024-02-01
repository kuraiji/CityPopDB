using System.Diagnostics.CodeAnalysis;
using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Services.AlbumService;

public class AlbumService : IAlbumService
{
    public async Task<string> Post(DataContext context, AlbumPostDto request)
    {
        var artist = await context.Artists.FirstOrDefaultAsync(a => a.Id == request.ArtistId);
        if (artist == null) throw new Exception("Artist Wasn't Found");
        await context.Albums.AddAsync(new Album
            {
                Name = request.Name,
                ImageLink = request.ImageLink,
                AlbumArtist = artist,
                Tracks = request.Tracks
            }
        );
        await context.SaveChangesAsync();
        return $"The album, {request.Name}, was successfully added to {artist.Name}";
    }

    public async Task<AlbumGetDto> Get(DataContext context, int id)
    {
        var album = await context.Albums.FindAsync(id);
        if (album == null) throw new Exception("Album Not Found");
        return new AlbumGetDto
        {
            Name = album.Name,
            ImageLink = album.ImageLink,
            Tracks = album.Tracks
        };
    }
    
    [SuppressMessage("ReSharper", "CA1862")]
    public async Task<List<AlbumGetSomeDto>> GetSome(DataContext context, string? filter, int page = 0, int items = 50, bool isDesc = false)
    {
        var albums = from album in context.Albums.Include(album => album.AlbumArtist)
            select new AlbumGetSomeDto
            {
                ArtistName = album.AlbumArtist.Name,
                AlbumName = album.Name
            };
        albums = isDesc ? 
            albums.OrderByDescending(a => a.AlbumName) : 
            albums.OrderBy(a => a.AlbumName);
        if (!string.IsNullOrWhiteSpace(filter))
            albums = albums.Where(a => a.AlbumName.ToLower().Contains(filter.ToLower()));
        albums = albums.Skip(items * int.Max(page, 0));
        albums = albums.Take(int.Min(items, 50));
        return await albums.ToListAsync();
    }

    public async Task<string> Delete(DataContext context, int id)
    {
        var album = await context.Albums.FindAsync(id);
        if (album == null) throw new Exception("Album Not Found");
        var name = album.Name;
        context.Albums.Remove(album);
        await context.SaveChangesAsync();
        return $"{name} was removed successfully";
    }

    public async Task<AlbumPutOutDto> Put(DataContext context, AlbumPutDto request)
    {
        var album = await context.Albums.Include(albums => albums.AlbumArtist).FirstOrDefaultAsync(album => album.Id == request.Id);
        var artist = await context.Artists.FindAsync(request.ArtistId);
        if (album == null) throw new Exception("Album Not Found");
        album.Name = request.Name;
        album.ImageLink = request.ImageLink;
        album.Tracks = request.Tracks;
        if(artist != null) album.AlbumArtist = artist;
        await context.SaveChangesAsync();
        return new AlbumPutOutDto
        {
            Name = album.Name,
            ImageLink = album.ImageLink,
            Tracks = album.Tracks,
            ArtistName = album.AlbumArtist.Name
        };
    }
}