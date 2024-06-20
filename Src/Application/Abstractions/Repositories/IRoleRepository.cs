using Domain.Entities;
using Resource = Application.Features.Competition;

namespace Application.Abstractions.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetAll();

    Task<Role> GetByName(string name);
}