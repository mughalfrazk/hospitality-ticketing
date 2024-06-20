using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface ICompetitionRepository
{
    Task<List<Competition>> GetAll();

    Competition GetById(int resourceId);
    
    Task<Competition> GetByName(string name);

    Task<Competition> AddNew(Competition toCreate, CancellationToken cancellationToken);

    Task<Competition> Update(Competition toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);

    bool IsValidId(int resourceId);
}