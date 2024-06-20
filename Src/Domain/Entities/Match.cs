namespace Domain.Entities;

public class Match : SoftDeletableEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int CompetitionId { get; set; }
    public virtual Competition Competition { get; set; }
    public int StadiumId { get; set; }
    public virtual Stadium Stadium { get; set; }
    public int TeamAId { get; set; }
    public virtual Team TeamA { get; set; }
    public int TeamBId { get; set; }
    public virtual Team TeamB { get; set; }
}