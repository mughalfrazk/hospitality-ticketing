using MediatR;

namespace Application.Features.Team.GetById;

public class Request : IRequest<ResultWrapper<Domain.Entities.Team>>
{
    public Request(int Id)
    {
        TeamId = Id;
    }
    
    public Request() {}
    
    internal int TeamId { get; set; }
}