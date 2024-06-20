using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.City.GetAll;

public class Handler(ICityRepository cityRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.City>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.City>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var cities = await cityRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.City>>.Ok(cities);
    }
}