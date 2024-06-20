using System.Data.Common;
using Application.Abstractions;
using Application.Context;
using MediatR;

namespace Application.Features.Match.Delete;

public class Handler(ITicketingContext ticketingCtx, IAuthUserProvider authProvider) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var match = ticketingCtx.Match.FirstOrDefault(t => t.Id == request.MatchId);
        if (match == default) return ResultWrapper<string>.NotFound("Resource not found.");
        
        match.Delete();
        match.SetModifiedBy(false, authProvider.GetEmail());
        await ticketingCtx.SaveToDbAsync(cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}