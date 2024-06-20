using MediatR;

namespace Application.Features.Stadium.Update;

public class Request : IRequest<ResultWrapper<Domain.Entities.Stadium>>
{
    public Request(Request req, int Id)
    {
        Name = req.Name;
        Address = req.Address;
        Lat = req.Lat;
        Lng = req.Lng;
        Postcode = req.Postcode;
        CityId = req.CityId;
        CountryId = req.CountryId;
        StadiumId = Id;
    }
    
    public Request() {}
    
    public string? Name { get; set; }
    public string? Address { get; set; }
    public double? Lat { get; set; }
    public double? Lng { get; set; }
    public string? Postcode { get; set; }
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    internal int StadiumId { get; set; }
}