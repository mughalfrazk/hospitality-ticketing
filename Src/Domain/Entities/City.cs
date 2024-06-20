namespace Domain.Entities;

public class City : SoftDeletableEntity
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
}