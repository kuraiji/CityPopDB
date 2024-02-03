using CityPopDB.Data;
using CityPopDB.DTOs;
using CityPopDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityPopDB.Services.VoteService;

public class VoteService : IVoteService
{
    public async Task<string> Post(DataContext context, VotePostDto request)
    {
        var user = await context.Users.FindAsync(request.UserId);
        if (user == null) throw new Exception("User Wasn't Found");
        var album = await context.Albums.FindAsync(request.AlbumId);
        if (album == null) throw new Exception("Album Wasn't Found");
        await context.Votes.AddAsync(new Vote
        {
            User = user,
            Album = album,
            Rating = request.Rating
        });
        await context.SaveChangesAsync();
        return $"The vote {request.Rating} was added for {user.UserName} on the album {album.Name}";
    }

    public async Task<List<VoteGetDto>> GetUser(DataContext context, string id)
    {
        var votes = from vote in context.Votes.Include(v => v.Album).Include(v => v.User)
                                        where vote.User.Id == id
                                        select new VoteGetDto
                                        {
                                            AlbumName = vote.Album.Name,
                                            UserName = vote.User.UserName,
                                            Rating = vote.Rating
                                        };
        return await votes.ToListAsync();
    }

    public async Task<List<VoteGetDto>> GetAlbum(DataContext context, int id)
    {
        var votes = from vote in context.Votes.Include(v => v.Album).Include(v => v.User)
            where vote.Album.Id == id
            select new VoteGetDto
            {
                AlbumName = vote.Album.Name,
                UserName = vote.User.UserName,
                Rating = vote.Rating
            };
        return await votes.ToListAsync();
    }

    public async Task<string> Delete(DataContext context, int id)
    {
        var voteQuery = await context.Votes.FindAsync(id);
        if (voteQuery == null) throw new Exception("Vote was not Found");
        var voteId = voteQuery.Id;
        context.Votes.Remove(voteQuery);
        await context.SaveChangesAsync();
        return $"The vote {voteId} was deleted";
    }

    public async Task<VoteGetDto> Put(DataContext context, VotePutDto request)
    {
        var voteQuery = await (from vote in context.Votes.Include(v => v.Album).Include(v => v.User)
            where vote.Album.Id == request.AlbumId && vote.User.Id == request.UserId
            select vote).FirstOrDefaultAsync();
        if (voteQuery == null) throw new Exception("Vote Not Found");
        voteQuery.Rating = request.Rating;
        await context.SaveChangesAsync();
        return new VoteGetDto
        {
            AlbumName = voteQuery.Album.Name,
            UserName = voteQuery.User.UserName ?? "Username Not Found",
            Rating = voteQuery.Rating
        };
    }
}