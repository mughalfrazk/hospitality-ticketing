using Domain.Entities;
using Resource = Application.Features.Match;

namespace Application.Abstractions.Repositories;

public interface ITeamRepository
{
    Task<List<Team>> GetAll();
    
    Task<Team> GetById(int resourceId);

    Task<Team> GetByName(string name);

    Task<Team> AddNew(Team toCreate, CancellationToken cancellationToken);

    Task<Team> Update(Team toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);
    
    bool IsValidId(int resourceId);
}