using Application.Context;
using MediatR;

namespace Application.Features.Match.GetById;

public class Handler(ITicketingContext ticketingCtx) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Match>>
{
    public async Task<ResultWrapper<Domain.Entities.Match>> Handle(Request request, CancellationToken cancellationToken)
    {
        var match = ticketingCtx.Match.FirstOrDefault(t => t.Id == request.MatchId);
        if (match == default) return ResultWrapper<Domain.Entities.Match>.NotFound("Resource not found.");
        
        return ResultWrapper<Domain.Entities.Match>.Ok(match);
    }
}