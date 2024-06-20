using Domain.Entities;
using Resource = Application.Features.Competition;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Users GetById(int resourceId);
    
    Task<Users> GetByEmail(string name);

    Task<Users> AddNew(Users toCreate, CancellationToken cancellationToken);

    Task<Users> Update(Users toUpdate, CancellationToken cancellationToken);

    Task Delete(int resourceId, CancellationToken cancellationToken);
    
    bool IsValidId(int resourceId);
}