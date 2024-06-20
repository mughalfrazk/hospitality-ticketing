using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetAll();

    Country GetById(int resourceId);
    
    Task<Country> GetByName(string name);

    Task<Country> AddNew(Country toCreate, CancellationToken cancellationToken);

    Task<Country> Update(Country toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);
    
    bool IsValidId(int resourceId);
}