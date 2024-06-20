using MediatR;

namespace Application.Features.Stadium.GetById;

public class Request : IRequest<ResultWrapper<Domain.Entities.Stadium>>
{
    public Request(int Id)
    {
        StadiumId = Id;
    }
    
    public Request() {}
    
    internal int StadiumId { get; set; }
}