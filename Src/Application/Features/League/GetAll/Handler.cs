using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.League.GetAll;

public class Handler(ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.League>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.League>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var leagues = await leagueRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.League>>.Ok(leagues);
    }
}