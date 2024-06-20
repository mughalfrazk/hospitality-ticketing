using MediatR;

namespace Application.Features.Competition.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        CompetitionId = id;
    }
    
    public Request() {}
    
    internal int CompetitionId { get; set; }
}