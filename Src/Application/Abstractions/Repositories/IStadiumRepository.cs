using Domain.Entities;
using Resource = Application.Features.Match;

namespace Application.Abstractions.Repositories;

public interface IStadiumRepository
{
    Task<List<Stadium>> GetAll();
    
    Task<Stadium> GetById(int resourceId);
    
    Task<Stadium> GetByName(string name);

    Task<Stadium> AddNew(Stadium toCreate, CancellationToken cancellationToken);

    Task<Stadium> Update(Stadium toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);
    
    bool IsValidId(int resourceId);
}