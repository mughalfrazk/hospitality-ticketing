using System.Data.Common;
using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Context;
using MediatR;

namespace Application.Features.Stadium.Delete;

public class Handler(IStadiumRepository stadiumRepository) : IRequestHandler<Request, ResultWrapper<string>>
{
    public async Task<ResultWrapper<string>> Handle(Request request, CancellationToken cancellationToken)
    {
        var stadium = await stadiumRepository.GetById(request.StadiumId);
        if (stadium == null) return ResultWrapper<string>.NotFound("Resource not found.");

        await stadiumRepository.Delete(request.StadiumId, cancellationToken);
        return ResultWrapper<string>.Ok("Resource deleted.");
    }
}