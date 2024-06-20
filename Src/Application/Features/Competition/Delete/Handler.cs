using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Competition.Delete;

public class Handler(ICompetitionRepository competitionRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var competition = competitionRepository.GetById(request.CompetitionId);
        if (competition == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await competitionRepository.Delete(request.CompetitionId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}