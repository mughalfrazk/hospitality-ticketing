namespace Domain.Entities;

public class Users : SoftDeletableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsVerified { get; set; }
    public bool IsActive { get; set; }
    public required string Phone { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
}