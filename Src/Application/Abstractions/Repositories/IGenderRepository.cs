using Domain.Entities;
using Resource = Application.Features.Competition;

namespace Application.Abstractions.Repositories;

public interface IGenderRepository
{
    Task<List<Gender>> GetAll();
}