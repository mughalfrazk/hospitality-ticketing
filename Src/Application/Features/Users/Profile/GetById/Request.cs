using MediatR;

namespace Application.Features.Users.Profile.GetById;

public class Request : IRequest<ResultWrapper<Response>>
{
    public Request(int userId)
    {
        Id = userId;
    }
    
    public Request() {}
    
    public int Id { get; set; }
}