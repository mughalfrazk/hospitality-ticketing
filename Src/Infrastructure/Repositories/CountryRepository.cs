using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class CountryRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : ICountryRepository
{
    public async Task<List<Country>> GetAll()
    {
        return await context.Country.ToListAsync();
    }

    public Country GetById(int countryId)
    {
        return context.Country.FirstOrDefault(c => c.Id == countryId)!;
    }

    public Task<Country> GetByName(string name)
    {
        return Task.FromResult(context.Country.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<Country> AddNew(Country toCreate, CancellationToken cancellationToken)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.Country.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;}
    
    public async Task<Country> Update(Country country,
        CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        country.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return country;
    }

    public async Task Delete(int countryId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var country = context.Country.FirstOrDefault(c => c.Id == countryId);

        country?.Delete();
        country?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }
    
    public bool IsValidId(int resourceId)
    {
        var firstOrDefault = context.Country.FirstOrDefault(c => c.Id == resourceId);
        return firstOrDefault != default;
    }
}