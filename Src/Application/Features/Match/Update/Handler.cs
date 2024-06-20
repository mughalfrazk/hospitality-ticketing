using Application.Abstractions;
using Application.Context;
using MediatR;

namespace Application.Features.Match.Update;

public class Handler(ITicketingContext ticketingCtx, IAuthUserProvider authProvider) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Match>>
{
    public async Task<ResultWrapper<Domain.Entities.Match>> Handle(Request request, CancellationToken cancellationToken)
    {
        var match = ticketingCtx.Match.FirstOrDefault(t => t.Id == request.CompetitionId);
        if (match == default) return ResultWrapper<Domain.Entities.Match>.NotFound("Resource not found.");

        if (request.Name != null) match.Name = request.Name;
        if (request.Description != null) match.Description = request.Description;
        if (request.CompetitionId != null) match.CompetitionId = (int)request.CompetitionId;
        if (request.StadiumId != null) match.StadiumId = (int)request.StadiumId;
        if (request.TeamAId != null) match.TeamAId = (int)request.TeamAId;
        if (request.TeamBId != null) match.TeamBId = (int)request.TeamBId;
        
        match.SetModifiedBy(false, authProvider.GetEmail());
        await ticketingCtx.SaveToDbAsync(cancellationToken);
        return ResultWrapper<Domain.Entities.Match>.Ok(match);
    }
}