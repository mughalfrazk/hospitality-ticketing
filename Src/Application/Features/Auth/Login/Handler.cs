using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using AutoMapper;
using MediatR;

namespace Application.Features.Auth.Login;

public class Handler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    IMapper mapper)
    : IRequestHandler<Request, ResultWrapper<Response>>
{
    public async Task<ResultWrapper<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmail(request.Email);

        if (user == null) return ResultWrapper<Response>.BadRequest("User not found.");
        if (!passwordHasher.Verify(user.Password, request.Password))
            return ResultWrapper<Response>.Forbidden("Invalid credentials");

        var result = mapper.Map<Response>(user);
        var tokenExpiry = DateTime.UtcNow.AddHours(6);
        
        result.AccessToken = jwtProvider.Generate(user, tokenExpiry);
        result.ExpiresAt = tokenExpiry;
        return ResultWrapper<Response>.Ok(result);
    }
}