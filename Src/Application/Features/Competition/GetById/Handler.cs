using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Competition.GetById;

public class Handler(ICompetitionRepository competitionRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Competition>>
{
    public async Task<ResultWrapper<Domain.Entities.Competition>> Handle(Request request, CancellationToken cancellationToken)
    {
        var competition = competitionRepository.GetById(request.CompetitionId);
        if (competition == null) return ResultWrapper<Domain.Entities.Competition>.NotFound("Resource not found.");
        
        return ResultWrapper<Domain.Entities.Competition>.Ok(competition);
    }
}