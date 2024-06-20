using MediatR;

namespace Application.Features.League.GetById;

public class Request : IRequest<ResultWrapper<Domain.Entities.League>>
{
    public Request(int Id)
    {
        LeagueId = Id;
    }
    
    public Request() {}
    
    internal int LeagueId { get; set; }
}