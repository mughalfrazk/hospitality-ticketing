using MediatR;

namespace Application.Features.City.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.City>>>
{
    
}