using MediatR;

namespace Application.Features.League.Update;

public class Request : IRequest<ResultWrapper<Domain.Entities.League>>
{
    public Request(Request req, int Id)
    {
        Name = req.Name;
        Description = req.Description;
        LeagueId = Id;
    }
    
    public Request() {}
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    internal int LeagueId { get; set; }
}