using Domain.Entities;
using Application.Context;
using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class UserRepository(ITicketingContext context, IAuthUserProvider authUserProvider)
    : IUserRepository
{
    public async Task<List<Users>> GetAll()
    {
        return await context.Users.ToListAsync();
    }

    public Users GetById(int resourceId)
    {
        return context.Users.FirstOrDefault(c => c.Id == resourceId)!;
    }

    public Task<Users> GetByEmail(string email)
    {
        return Task.FromResult(context.Users.FirstOrDefault(c => c.Email == email)!);
    }

    public async Task<Users> AddNew(Users toCreate, CancellationToken cancellationToken)
    {
        var authEmail = authUserProvider.GetEmail();

        toCreate.SetModifiedBy(true, authEmail);
        context.Users.Add(toCreate);
        await context.SaveToDbAsync(cancellationToken);
        return toCreate;
    }

    public async Task<Users> Update(Users toUpdate, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();

        toUpdate.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
        return toUpdate;
    }

    public async Task Delete(int resourceId, CancellationToken cancellationToken = default)
    {
        var authEmail = authUserProvider.GetEmail();
        var city = context.Users.FirstOrDefault(c => c.Id == resourceId);

        city?.Delete();
        city?.SetModifiedBy(false, authEmail);
        await context.SaveToDbAsync(cancellationToken);
    }

    public bool IsValidId(int resourceId)
    {
        var firstOrDefault = context.Team.FirstOrDefault(c => c.Id == resourceId);
        return firstOrDefault != default;
    }
}