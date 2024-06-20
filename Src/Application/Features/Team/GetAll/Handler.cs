using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Team.GetAll;

public class Handler(ITeamRepository teamRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Team>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Team>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var teams = await teamRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Team>>.Ok(teams);
    }
}