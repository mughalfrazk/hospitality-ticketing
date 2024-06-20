using Domain.Entities;

namespace Application.Features.Auth.Login;

public class Response
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Domain.Entities.Role Role { get; set; }
    public string? AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
}