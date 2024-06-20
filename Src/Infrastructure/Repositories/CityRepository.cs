using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class CityRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : ICityRepository
{
    public async Task<List<City>> GetAll()
    {
        return await context.City.ToListAsync();
    }

    public City GetById(int countryId)
    {
        return context.City.FirstOrDefault(c => c.Id == countryId)!;
    }

    public Task<City> GetByName(string name)
    {
        return Task.FromResult(context.City.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<City> AddNew(City toCreate, CancellationToken cancellationToken)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.City.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<City> Update(City city, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        city.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return city;
    }

    public async Task Delete(int cityId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var city = context.City.FirstOrDefault(c => c.Id == cityId);

        city?.Delete();
        city?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }
    
    public bool IsValidId(int resourceId)
    {
        var firstOrDefault = context.Country.FirstOrDefault(c => c.Id == resourceId);
        return firstOrDefault != default;
    }
}