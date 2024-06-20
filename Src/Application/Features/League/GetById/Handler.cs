using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.League.GetById;

public class Handler(ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.League>>
{
    public async Task<ResultWrapper<Domain.Entities.League>> Handle(Request request, CancellationToken cancellationToken)
    {
        var league = await leagueRepository.GetById(request.LeagueId);
        if (league == null) return ResultWrapper<Domain.Entities.League>.NotFound("Resource not found.");
        
        return ResultWrapper<Domain.Entities.League>.Ok(league);
    }
}