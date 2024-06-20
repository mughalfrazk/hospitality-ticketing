using Application.Abstractions.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class MatchRepository : IMatchRepository
{
    public Task<ICollection<Match>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Match> GetById(int resourceId)
    {
        throw new NotImplementedException();
    }

    public Task<Match> AddNew(Competition toCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Match> Update(Competition toUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Match> AddNew(Match toCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Match> Update(Match toUpdate, string email)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int resourceId)
    {
        throw new NotImplementedException();
    }

    public bool IsValidId(int resourceId)
    {
        throw new NotImplementedException();
    }
}