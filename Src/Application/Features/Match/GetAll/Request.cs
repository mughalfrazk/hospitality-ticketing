using MediatR;

namespace Application.Features.Match.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Match>>>
{
    
}