using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Stadium.Create;

public class Handler(IStadiumRepository stadiumRepository, ICountryRepository countryRepository, ICityRepository cityRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Stadium>>
{
    public async Task<ResultWrapper<Domain.Entities.Stadium>> Handle(Request request, CancellationToken cancellationToken)
    {
        var checkDuplicate = await stadiumRepository.GetByName(request.Name);
        if (checkDuplicate != null) return ResultWrapper<Domain.Entities.Stadium>.BadRequest("Stadium already exists.");

        var validCountry = countryRepository.IsValidId(request.CountryId);
        if (!validCountry) return ResultWrapper<Domain.Entities.Stadium>.BadRequest("Invalid country id.");
        
        var validCity = cityRepository.IsValidId(request.CityId);
        if (!validCity) return ResultWrapper<Domain.Entities.Stadium>.BadRequest("Invalid city id.");
        
        var stadium = new Domain.Entities.Stadium
        {
            Name = request.Name,
            Address = request.Address,
            Lat = request.Lat,
            Lng = request.Lng,
            Postcode = request.Postcode,
            CityId = request.CityId,
            CountryId = request.CountryId
        };

        await stadiumRepository.AddNew(stadium, cancellationToken);
        return ResultWrapper<Domain.Entities.Stadium>.Ok(stadium);
    }
}