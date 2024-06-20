namespace Domain.Entities;

public class Team : SoftDeletableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    public int StadiumId { get; set; }
    public virtual Stadium Stadium { get; set; }
    
    public int LeagueId { get; set; }
    public virtual League League { get; set; }
}