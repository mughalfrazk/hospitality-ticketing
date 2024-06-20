using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using Infrastructure.Authentication;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TicketingContext>(options =>
        {
            var config = configuration.GetConnectionString("DB");
            options.UseSqlServer(config);
        });

        services.AddScoped<ITicketingContext>(o =>
            o.GetService<TicketingContext>() ?? throw new Exception("Infrastructure Error: Couldn't connect to DB."));
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IAuthUserProvider, AuthUserProvider>();

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IGenderRepository, GenderRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICompetitionRepository, CompetitionRepository>();
        services.AddScoped<IStadiumRepository, StadiumRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}