namespace Movies.Application.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid UserId { get; set; }
    public ICollection<User> Users;
}