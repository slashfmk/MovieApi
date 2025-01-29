namespace Movies.Application.Dtos.Responses;

public class UserResponse
{
    public required Guid Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
}