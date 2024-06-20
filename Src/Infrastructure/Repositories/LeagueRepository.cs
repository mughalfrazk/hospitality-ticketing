using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class LeagueRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : ILeagueRepository
{
    public async Task<List<League>> GetAll()
    {
        return await context.League.ToListAsync();
    }

    public Task<League> GetById(int resourceId)
    {
        return Task.FromResult(context.League.FirstOrDefault(c => c.Id == resourceId)!);
    }

    public Task<League> GetByName(string name)
    {
        return Task.FromResult(context.League.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<League> AddNew(League toCreate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.League.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<League> Update(League toUpdate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toUpdate.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return toUpdate;
    }

    public async Task Delete(int resourceId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var team = context.Team.FirstOrDefault(c => c.Id == resourceId);

        team?.Delete();
        team?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }
    
    public bool IsValidId(int resourceId)
    {
        var firstOrDefault = context.Team.FirstOrDefault(c => c.Id == resourceId);
        return firstOrDefault != default;
    }
}