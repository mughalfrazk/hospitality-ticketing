using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Stadium.GetAll;

public class Handler(IStadiumRepository stadiumRepository) : IRequestHandler<Request, ResultWrapper<List<Domain.Entities.Stadium>>>
{
    public async Task<ResultWrapper<List<Domain.Entities.Stadium>>> Handle(Request request, CancellationToken cancellationToken)
    {
        var stadiums = await stadiumRepository.GetAll();
        return ResultWrapper<List<Domain.Entities.Stadium>>.Ok(stadiums);
    }
}