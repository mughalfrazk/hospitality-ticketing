namespace Domain.Entities;

public class League : SoftDeletableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}