using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class StadiumRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : IStadiumRepository
{
    public async Task<List<Stadium>> GetAll()
    {
        return await context.Stadium.ToListAsync();
    }

    public Task<Stadium> GetById(int resourceId)
    {
        return Task.FromResult(context.Stadium.FirstOrDefault(c => c.Id == resourceId)!);
    }

    public Task<Stadium> GetByName(string name)
    {
        return Task.FromResult(context.Stadium.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<Stadium> AddNew(Stadium toCreate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.Stadium.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<Stadium> Update(Stadium stadium, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        stadium.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return stadium;
    }

    public async Task Delete(int resourceId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var competition = context.Stadium.FirstOrDefault(c => c.Id == resourceId);

        competition?.Delete();
        competition?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }
    
    public bool IsValidId(int resourceId)
    {
        var firstOrDefault = context.Stadium.FirstOrDefault(c => c.Id == resourceId);
        return firstOrDefault != default;
    }
}