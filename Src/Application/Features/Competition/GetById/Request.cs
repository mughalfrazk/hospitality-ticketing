using MediatR;

namespace Application.Features.Competition.GetById;

public class Request : IRequest<ResultWrapper<Domain.Entities.Competition>>
{
    public Request(int Id)
    {
        CompetitionId = Id;
    }
    
    public Request() {}
    
    internal int CompetitionId { get; set; }
}