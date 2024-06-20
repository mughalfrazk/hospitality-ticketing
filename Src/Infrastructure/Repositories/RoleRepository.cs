using Domain.Entities;
using Application.Context;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class RoleRepository(ITicketingContext context) : IRoleRepository
{
    public async Task<List<Role>> GetAll()
    {
        return await context.Role.ToListAsync();
    }

    public async Task<Role> GetByName(string name)
    {
        return context.Role.FirstOrDefault(r => r.Name == name);
    }
}