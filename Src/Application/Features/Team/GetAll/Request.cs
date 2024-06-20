using MediatR;

namespace Application.Features.Team.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Team>>>
{
    
}