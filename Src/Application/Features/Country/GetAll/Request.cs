using MediatR;

namespace Application.Features.Country.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Country>>>
{
    
}