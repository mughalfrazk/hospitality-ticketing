using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Stadium.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.Stadium>>
{
    public Request(Request req)
    {
        Name = req.Name;
        Address = req.Address;
        Lat = req.Lat;
        Lng = req.Lng;
        Postcode = req.Postcode;
        CityId = req.CityId;
        CountryId = req.CountryId;
    }
    
    public Request() {}
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public double Lat { get; set; }
    [Required]
    public double Lng { get; set; }
    [Required]
    public string Postcode { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Valid country id is required")]
    public int CountryId { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Valid city id is required")]
    public int CityId { get; set; }
}