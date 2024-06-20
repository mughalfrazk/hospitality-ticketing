using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.Competition.Create;

public class Handler(ICompetitionRepository competitionRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Competition>>
{
    public async Task<ResultWrapper<Domain.Entities.Competition>> Handle(Request request, CancellationToken cancellationToken)
    {
        var duplicate = await competitionRepository.GetByName(request.Name);
        if (duplicate != null)
        {
            return ResultWrapper<Domain.Entities.Competition>.BadRequest("Competition already exists.");
        }

        var competition = new Domain.Entities.Competition
        {
            Name = request.Name,
            Description = request.Description ?? ""
        };
        await competitionRepository.AddNew(competition, cancellationToken);
        return ResultWrapper<Domain.Entities.Competition>.Ok(competition);
    }
}