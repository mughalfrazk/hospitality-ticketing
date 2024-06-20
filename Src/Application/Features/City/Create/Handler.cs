using Application.Abstractions.Repositories;
using MediatR;

namespace Application.Features.City.Create;

public class Handler(ICountryRepository countryRepository, ICityRepository cityRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.City>>
{
    public async Task<ResultWrapper<Domain.Entities.City>> Handle(Request request, CancellationToken cancellationToken)
    {
        var duplicate = await cityRepository.GetByName(request.Name);
        if (duplicate != null) return ResultWrapper<Domain.Entities.City>.BadRequest("City already exists.");

        var validCountryId = countryRepository.IsValidId(request.CountryId);
        if (!validCountryId) return ResultWrapper<Domain.Entities.City>.BadRequest("Invalid country Id.");
        
        var city = new Domain.Entities.City
        {
            Name = request.Name,
            CountryId = request.CountryId
        };

        await cityRepository.AddNew(city, cancellationToken);
        return ResultWrapper<Domain.Entities.City>.Ok(city);
    }
}