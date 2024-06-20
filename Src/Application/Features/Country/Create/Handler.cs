using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Country.Create;

public class Handler(ICountryRepository countryRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Country>>
{
    public async Task<ResultWrapper<Domain.Entities.Country>> Handle(Request request, CancellationToken cancellationToken)
    {
        var duplicate = await countryRepository.GetByName(request.Name);
        if (duplicate != null)
        {
            return ResultWrapper<Domain.Entities.Country>.BadRequest("Country already exists.");
        }

        var country = new Domain.Entities.Country
        {
            Name = request.Name
        };
        await countryRepository.AddNew(country, cancellationToken);
        return ResultWrapper<Domain.Entities.Country>.Ok(country);
    }
}