namespace Application.Features.Users.Profile.GetById;

internal class Mapper : AutoMapper.Profile
{
    public Mapper()
    {
        CreateMap<Domain.Entities.Users, Response>();
    }
}