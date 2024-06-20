using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Competition.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.Competition>>
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