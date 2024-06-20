using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Competition.GetAll;

public class Handler(ICompetitionRepository competitionRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Competition>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Competition>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var competitions = await competitionRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Competition>>.Ok(competitions);
    }
}