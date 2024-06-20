using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Team.Update;

public class Handler(
    ITeamRepository teamRepository,
    IStadiumRepository stadiumRepository,
    ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Team>>
{
    public async Task<ResultWrapper<Domain.Entities.Team>> Handle(Request request, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(request.TeamId);
        if (team == null) return ResultWrapper<Domain.Entities.Team>.NotFound("Resource not found.");

        if (request.Name != null) team.Name = request.Name;
        if (request.Description != null) team.Description = request.Description;

        if (request.StadiumId != 0)
        {
            var validStadium = stadiumRepository.IsValidId(request.StadiumId);
            if (!validStadium) return ResultWrapper<Domain.Entities.Team>.BadRequest("Invalid stadium id.");
        }

        if (request.LeagueId != 0)
        {
            var validLeague = leagueRepository.IsValidId(request.LeagueId);
            if (!validLeague) return ResultWrapper<Domain.Entities.Team>.BadRequest("Invalid league id.");
        }

        await teamRepository.Update(team, cancellationToken);
        return ResultWrapper<Domain.Entities.Team>.Ok(team);
    }
}