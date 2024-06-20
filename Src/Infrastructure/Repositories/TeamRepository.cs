using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class TeamRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : ITeamRepository
{
    public async Task<List<Team>> GetAll()
    {
        return await context.Team.ToListAsync();
    }

    public Task<Team> GetById(int resourceId)
    {
        return Task.FromResult(context.Team.FirstOrDefault(c => c.Id == resourceId)!);
    }

    public Task<Team> GetByName(string name)
    {
        return Task.FromResult(context.Team.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<Team> AddNew(Team toCreate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.Team.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<Team> Update(Team toUpdate, CancellationToken cancellationToken = default)
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