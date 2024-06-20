using Domain.Entities;
using Resource = Application.Features.Competition;

namespace Application.Abstractions.Repositories;

public interface ICityRepository
{
    Task<List<City>> GetAll();

    City GetById(int resourceId);
    
    Task<City> GetByName(string name);

    Task<City> AddNew(City toCreate, CancellationToken cancellationToken);

    Task<City> Update(City toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);

    bool IsValidId(int resourceId);
}