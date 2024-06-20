using Application.Abstractions.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Profile.GetById;

public class Handler(IUserRepository userRepository, IMapper _mapper)
    : IRequestHandler<Request, ResultWrapper<Response>>
{
    public async Task<ResultWrapper<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetById(request.Id);
        var mappedUser = _mapper.Map<Response>(user);
        return ResultWrapper<Response>.Ok(mappedUser);
    }
}