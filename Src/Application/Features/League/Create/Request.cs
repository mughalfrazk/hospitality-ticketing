using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.League.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.League>>
{
    public Request(Request req)
    {
        Name = req.Name;
        Description = req.Description;
    }
    
    public Request() {}
    
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
}