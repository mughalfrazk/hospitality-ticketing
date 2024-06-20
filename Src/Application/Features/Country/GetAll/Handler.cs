using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Country.GetAll;

public class Handler(ICountryRepository countryRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Country>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Country>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Country>>.Ok(countries);
    }
}