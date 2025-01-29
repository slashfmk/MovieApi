namespace Movies.Application.Models;

public class Rating
{
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    
    public DateTime RatedAt { get; set; }
    public int RatingScore { get; set; }

    public User User;
    public Movie Movie;
}