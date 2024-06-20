using MediatR;

namespace Application.Features.League.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.League>>>
{
    
}