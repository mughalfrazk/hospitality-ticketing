using System.Data.Common;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Country.Delete;

public class Handler(ICountryRepository countryRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var country = countryRepository.GetById(request.CountryId);
        if (country == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await countryRepository.Delete(request.CountryId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}