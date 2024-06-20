using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class CompetitionRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : ICompetitionRepository
{
    public async Task<List<Competition>> GetAll()
    {
        return await context.Competition.ToListAsync();
    }

    public bool IsValidId(int competitionId)
    {
        var firstOrDefault = context.Competition.FirstOrDefault(c => c.Id == competitionId);
        return firstOrDefault != default;
    }

    public Competition GetById(int competitionId)
    {
        return context.Competition.FirstOrDefault(c => c.Id == competitionId)!;
    }

    public Task<Competition> GetByName(string name)
    {
        return Task.FromResult(context.Competition.FirstOrDefault(c => c.Name == name)!);
    }

    public async Task<Competition> AddNew(Competition toCreate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.Competition.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<Competition> Update(Competition competition,
        CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        competition.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return competition;
    }

    public async Task Delete(int competitionId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var competition = context.Competition.FirstOrDefault(c => c.Id == competitionId);

        competition?.Delete();
        competition?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }
}