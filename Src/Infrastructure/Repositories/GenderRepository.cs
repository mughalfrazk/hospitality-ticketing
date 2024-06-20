using Domain.Entities;
using Application.Context;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Repositories;

namespace Infrastructure.Repositories;

public class GenderRepository(ITicketingContext context) : IGenderRepository
{
    public async Task<List<Gender>> GetAll()
    {
        return await context.Gender.ToListAsync();
    }
}