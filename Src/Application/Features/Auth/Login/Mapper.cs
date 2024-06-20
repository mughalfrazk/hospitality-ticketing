using AutoMapper;

namespace Application.Features.Auth.Login;

internal class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Domain.Entities.Users, Response>();
    }
}