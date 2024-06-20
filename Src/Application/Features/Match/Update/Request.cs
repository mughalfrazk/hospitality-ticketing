using MediatR;

namespace Application.Features.Match.Update;

public class Request : IRequest<ResultWrapper<Domain.Entities.Match>>
{
    public Request(Request req, int id)
    {
        Name = req.Name;
        Description = req.Description;
        CompetitionId = req.CompetitionId;
        StadiumId = req.StadiumId;
        TeamAId = req.TeamAId;
        TeamBId = req.TeamBId;
        MatchId = id;
    }
    
    public Request() {}
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? CompetitionId { get; set; }
    public int? StadiumId { get; set; }
    public int? TeamAId { get; set; }
    public int? TeamBId { get; set; }
    internal int MatchId { get; set; }
}