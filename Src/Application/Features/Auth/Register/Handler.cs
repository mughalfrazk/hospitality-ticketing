using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Auth.Register;

public class Handler(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher)
    : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var hashedPassword = passwordHasher.Hash(request.Password);
        var userRole = await roleRepository.GetByName("client");
        
        var newUser = new Domain.Entities.Users
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = hashedPassword,
            IsActive = false,
            IsVerified = false,
            Phone = request.Phone,
            RoleId = userRole.Id 
        };
        
        await userRepository.AddNew(newUser, cancellationToken);
        return ResultWrapper<string>.Ok(
            "User created successfully, please follow the instructions in your email and login again.");
    }
}