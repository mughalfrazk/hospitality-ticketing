using MediatR;

namespace Application.Features.Team.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        TeamId = id;
    }
    
    public Request() {}
    
    internal int TeamId { get; set; }
}