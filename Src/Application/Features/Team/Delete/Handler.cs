using System.Data.Common;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Team.Delete;

public class Handler(ITeamRepository teamRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(request.TeamId);
        if (team == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await teamRepository.Delete(request.TeamId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}