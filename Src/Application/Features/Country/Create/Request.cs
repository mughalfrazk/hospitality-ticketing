using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Country.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.Country>>
{
    public Request(Request req)
    {
        Name = req.Name;
    }
    
    public Request() {}
    
    [Required]
    public string Name { get; set; }
}