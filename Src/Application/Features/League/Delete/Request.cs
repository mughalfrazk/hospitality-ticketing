using MediatR;

namespace Application.Features.League.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        LeagueId = id;
    }
    
    public Request() {}
    
    internal int LeagueId { get; set; }
}