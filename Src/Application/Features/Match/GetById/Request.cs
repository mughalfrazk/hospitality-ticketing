using MediatR;

namespace Application.Features.Match.GetById;

public class Request : IRequest<ResultWrapper<Domain.Entities.Match>>
{
    public Request(int id)
    {
        MatchId = id;
    }
    
    public Request() {}
    
    internal int MatchId { get; set; }
}