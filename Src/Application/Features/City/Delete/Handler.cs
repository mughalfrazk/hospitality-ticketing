using System.Data.Common;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.City.Delete;

public class Handler(ICityRepository cityRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var city = cityRepository.GetById(request.CityId);
        if (city == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await cityRepository.Delete(request.CityId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}