using MediatR;

namespace Application.Features.Role.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Role>>>
{
    
}