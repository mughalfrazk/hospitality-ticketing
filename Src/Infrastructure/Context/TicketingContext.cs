using System.Reflection;
using Application.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class TicketingContext : DbContext, ITicketingContext
{
    public TicketingContext(DbContextOptions<TicketingContext> options) : base(options) 
    { 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType.GetProperties().Any(p => p.Name == "DeletedOn"));
            
        foreach (var mutableEntityType in entityTypes)
        {
            var method = SetGlobalQueryMethodInfo.MakeGenericMethod(mutableEntityType.ClrType);
            method.Invoke(this, new object[] { modelBuilder });
        }
    }

    public static readonly MethodInfo SetGlobalQueryMethodInfo = typeof(TicketingContext)
        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

    public void SetGlobalQuery<T>(ModelBuilder modelBuilder) where T : class
    {
        modelBuilder.Entity<T>().HasQueryFilter(e => EF.Property<DateTime?>(e, "DeletedOn") == null);
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Gender> Gender { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Stadium> Stadium { get; set; }
    public DbSet<Match> Match { get; set; }
    public DbSet<League> League { get; set; }
    public DbSet<Competition> Competition { get; set; }
    public Task<int> SaveToDbAsync(CancellationToken cancellationToken = default)
    {
        return SaveChangesAsync(cancellationToken);
    }
}