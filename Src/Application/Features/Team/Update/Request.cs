using MediatR;

namespace Application.Features.Team.Update;

public class Request : IRequest<ResultWrapper<Domain.Entities.Team>>
{
    public Request(Request req, int id)
    {
        Name = req.Name;
        Description = req.Description;
        StadiumId = req.StadiumId;
        LeagueId = req.LeagueId;
        TeamId = id;
    }
    
    public Request() {}
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StadiumId { get; set; }
    public int LeagueId { get; set; }
    internal int TeamId { get; set; }
}