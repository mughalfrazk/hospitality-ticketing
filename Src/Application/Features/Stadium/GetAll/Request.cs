using MediatR;

namespace Application.Features.Stadium.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Stadium>>>
{
    
}