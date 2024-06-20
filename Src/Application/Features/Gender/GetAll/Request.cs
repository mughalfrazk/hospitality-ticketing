using MediatR;

namespace Application.Features.Gender.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Gender>>>
{
    
}