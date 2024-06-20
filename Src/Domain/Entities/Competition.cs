namespace Domain.Entities;

public class Competition : SoftDeletableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}