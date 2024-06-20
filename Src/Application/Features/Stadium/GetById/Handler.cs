using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Stadium.GetById;

public class Handler(IStadiumRepository stadiumRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Stadium>>
{
    public async Task<ResultWrapper<Domain.Entities.Stadium>> Handle(Request request, CancellationToken cancellationToken)
    {
        var stadium = await stadiumRepository.GetById(request.StadiumId);
        if (stadium == default) return ResultWrapper<Domain.Entities.Stadium>.NotFound("Resource not found.");
        
        return ResultWrapper<Domain.Entities.Stadium>.Ok(stadium);
    }
}