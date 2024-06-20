using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Team.Create;

public class Handler(
    ITeamRepository teamRepository,
    IStadiumRepository stadiumRepository,
    ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Team>>
{
    public async Task<ResultWrapper<Domain.Entities.Team>> Handle(Request request, CancellationToken cancellationToken)
    {
        var checkDuplicate = await teamRepository.GetByName(request.Name);
        if (checkDuplicate != null) return ResultWrapper<Domain.Entities.Team>.BadRequest("Team already exists.");

        var validStadium = stadiumRepository.IsValidId(request.StadiumId);
        if (!validStadium) return ResultWrapper<Domain.Entities.Team>.BadRequest("Invlaid stadium id.");

        var validLeague = leagueRepository.IsValidId(request.LeagueId);
        if (!validLeague) return ResultWrapper<Domain.Entities.Team>.BadRequest("Invlaid league id.");

        var team = new Domain.Entities.Team
        {
            Name = request.Name,
            Description = request.Description,
            LeagueId = request.LeagueId,
            StadiumId = request.StadiumId
        };

        await teamRepository.AddNew(team, cancellationToken);
        return ResultWrapper<Domain.Entities.Team>.Ok(team);
    }
}