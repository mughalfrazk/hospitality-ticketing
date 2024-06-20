namespace Domain.Entities;

public class Stadium : SoftDeletableEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string Postcode { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public int CityId { get; set; }
    public virtual City City { get; set; }
}