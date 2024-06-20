using MediatR;

namespace Application.Features.Stadium.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int Id)
    {
        StadiumId = Id;
    }
    
    public Request() {}
    
    internal int StadiumId { get; set; }
}