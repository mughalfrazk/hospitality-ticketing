using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Match.Create;

public class Handler(ITicketingContext ticketingCtx, IAuthUserProvider authProvider, ICompetitionRepository competitionRepo) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Match>>
{
    public async Task<ResultWrapper<Domain.Entities.Match>> Handle(Request request, CancellationToken cancellationToken)
    {
        var checkDuplicate = ticketingCtx.Match.FirstOrDefault(t => t.Name == request.Name);
        if (checkDuplicate != default) return ResultWrapper<Domain.Entities.Match>.BadRequest("Match already exists.");
        
        
        if (!competitionRepo.IsValidId(request.CompetitionId))
        {
            return ResultWrapper<Domain.Entities.Match>.BadRequest("A valid competition Id is required");
        }
        
        var match = new Domain.Entities.Match
        {
            Name = request.Name,
            Description = request.Description
        };
        
        // match.SetModifiedBy(true, authProvider.GetEmail());
        // ticketingCtx.Match.Add(match);
        // await ticketingCtx.SaveToDBAsync(cancellationToken);

        return ResultWrapper<Domain.Entities.Match>.Ok(match);
    }
}