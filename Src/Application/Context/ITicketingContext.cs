using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Context;

public interface ITicketingContext
{
    public DbSet<Users> Users { get; }
    public DbSet<Role> Role { get; }
    public DbSet<Gender> Gender { get; }
    public DbSet<Country> Country { get; }
    public DbSet<City> City { get; }
    public DbSet<Team> Team { get; }
    public DbSet<Stadium> Stadium { get; }
    public DbSet<Match> Match { get; }
    public DbSet<League> League { get; }
    public DbSet<Competition> Competition { get; }
    Task<int> SaveToDbAsync(CancellationToken cancellationToken = default);
}