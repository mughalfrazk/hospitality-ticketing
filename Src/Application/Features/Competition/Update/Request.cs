using MediatR;

namespace Application.Features.Competition.Update;

public class Request : IRequest<ResultWrapper<Domain.Entities.Competition>>
{
    public Request(Request req, int Id)
    {
        Name = req.Name;
        Description = req.Description;
        CompetitionId = Id;
    }
    
    public Request() {}
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    internal int CompetitionId { get; set; }
}