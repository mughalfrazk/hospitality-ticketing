using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Gender.GetAll;

public class Handler(IGenderRepository genderRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Gender>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Gender>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var genders = await genderRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Gender>>.Ok(genders);
    }
}