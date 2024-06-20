using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.League.Create;

public class Handler(ILeagueRepository leagueRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.League>>
{
    public async Task<ResultWrapper<Domain.Entities.League>> Handle(Request request, CancellationToken cancellationToken)
    {
        var duplicate = await leagueRepository.GetByName(request.Name);
        if (duplicate != null)
        {
            return ResultWrapper<Domain.Entities.League>.BadRequest("League already exists.");
        }

        var league = new Domain.Entities.League
        {
            Name = request.Name,
            Description = request.Description ?? ""
        };
        await leagueRepository.AddNew(league, cancellationToken);
        return ResultWrapper<Domain.Entities.League>.Ok(league);
    }
}