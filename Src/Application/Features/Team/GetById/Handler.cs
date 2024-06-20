using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Team.GetById;

public class Handler(ITeamRepository teamRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Team>>
{
    public async Task<ResultWrapper<Domain.Entities.Team>> Handle(Request request, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(request.TeamId);
        if (team == null) return ResultWrapper<Domain.Entities.Team>.NotFound("Resource not found.");
        
        return ResultWrapper<Domain.Entities.Team>.Ok(team);
    }
}