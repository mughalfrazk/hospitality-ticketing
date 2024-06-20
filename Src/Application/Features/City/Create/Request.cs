using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.City.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.City>>
{
    public Request(Request req)
    {
        Name = req.Name;
        CountryId = req.CountryId;
    }
    
    public Request() {}
    
    [Required]
    public string Name { get; set; }
    public int CountryId { get; set; }
}