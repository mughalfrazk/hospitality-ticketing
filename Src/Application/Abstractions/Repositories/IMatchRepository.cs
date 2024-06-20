using Domain.Entities;
using Resource = Application.Features.Match;

namespace Application.Abstractions.Repositories;

public interface IMatchRepository
{
    Task<ICollection<Match>> GetAll();
    
    Task<Match> GetById(int resourceId);

    Task<Match> AddNew(Competition toCreate, CancellationToken cancellationToken);

    Task<Match> Update(Competition toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId);
    
    bool IsValidId(int resourceId);
}