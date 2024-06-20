using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Team.Create;

public class Request : IRequest<ResultWrapper<Domain.Entities.Team>>
{
    public Request(Request req)
    {
        Name = req.Name;
        Description = req.Description;
        LeagueId = req.LeagueId;
        StadiumId = req.StadiumId;
    }

    public Request()
    {
    }

    [Required] public string Name { get; set; }
    public string? Description { get; set; }
    public int StadiumId { get; set; }
    public int LeagueId { get; set; }
}