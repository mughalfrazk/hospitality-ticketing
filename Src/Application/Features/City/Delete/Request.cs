using MediatR;

namespace Application.Features.City.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        CityId = id;
    }
    
    public Request() {}
    
    internal int CityId { get; set; }
}