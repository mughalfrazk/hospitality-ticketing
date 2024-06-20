using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Role.GetAll;

public class Handler(IRoleRepository roleRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Role>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Role>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Role>>.Ok(roles);
    }
}