using MediatR;

namespace Application.Features.Country.Delete;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(int id)
    {
        CountryId = id;
    }
    
    public Request() {}
    
    internal int CountryId { get; set; }
}