using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Stadium.Update;

public class Handler(IStadiumRepository stadiumRepository) : IRequestHandler<Request, ResultWrapper<Domain.Entities.Stadium>>
{
    public async Task<ResultWrapper<Domain.Entities.Stadium>> Handle(Request request, CancellationToken cancellationToken)
    {
        var stadium = await stadiumRepository.GetById(request.StadiumId);
        if (stadium == null) return ResultWrapper<Domain.Entities.Stadium>.NotFound("Resource not found.");

        if (request.Name != null) stadium.Name = request.Name;
        if (request.Address != null) stadium.Address = request.Address;
        if (request.Lat != null) stadium.Lat = (double)request.Lat;
        if (request.Lng != null) stadium.Lng = (double)request.Lng;
        if (request.Postcode != null) stadium.Postcode = request.Postcode;
        if (request.CityId != null) stadium.CityId = (int)request.CityId;
        if (request.CountryId != null) stadium.CountryId = (int)request.CountryId;

        await stadiumRepository.Update(stadium, cancellationToken);
        return ResultWrapper<Domain.Entities.Stadium>.Ok(stadium);
    }
}