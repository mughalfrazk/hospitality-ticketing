using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.League.Delete;

public class Handler(ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var competition = await leagueRepository.GetById(request.LeagueId);
        if (competition == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await leagueRepository.Delete(request.LeagueId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}