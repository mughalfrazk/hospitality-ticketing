using MediatR;

namespace Application.Features.Match.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        MatchId = id;
    }
    
    public Request() {}
    
    internal int MatchId { get; set; }
}