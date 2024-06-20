using MediatR;

namespace Application.Features.Competition.GetAll;

public class Request : IRequest<ResultWrapper<List<Domain.Entities.Competition>>>
{
    
}