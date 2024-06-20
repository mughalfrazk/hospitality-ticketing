using Domain.Entities;
using Resource = Application.Features.Match;

namespace Application.Abstractions.Repositories;

public interface ILeagueRepository
{
    Task<List<League>> GetAll();
    
    Task<League> GetById(int resourceId);

    Task<League> GetByName(string name);

    Task<League> AddNew(League toCreate, CancellationToken cancellationToken);

    Task<League> Update(League toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);
    
    bool IsValidId(int resourceId);
}