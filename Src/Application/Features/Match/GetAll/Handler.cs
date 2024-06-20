using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Match.GetAll;

public class Handler(ITicketingContext ticketingCtx) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Match>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Match>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var matches = await ticketingCtx.Match.ToListAsync(cancellationToken);
        return ResultWrapper<List<Domain.Entities.Match>>.Ok(matches);
    }
}