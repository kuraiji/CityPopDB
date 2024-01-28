namespace CityPopDB.Entities;

public class Vote
{
    public int Id { get; set; }
    public required double Rating { get; set; }
    public required User User { get; set; }
    public required Album Album { get; set; }
}