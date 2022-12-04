namespace Application.Handlers.PrioritiesHandler.Queries;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;

public record GetByIdPriorityHandler(IRepository Repository) : IQueryHandler<long, GetByIdPrioritiesDTO>
{
    public async Task<QResult<GetByIdPrioritiesDTO?>> Handle(QueryRequest<long, GetByIdPrioritiesDTO> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<Priority, GetByIdPrioritiesDTO>()
        {
            SpecificationFunc = _ =>
            _.Where(x => x.Id == request.Request)
            .Select(o => new GetByIdPrioritiesDTO()
            { Id = o.Id, Name = o.Name, PriorityLevel = o.PriorityLevel, ColorCode = o.ColorCode })
        };
        var response = await Repository.FirstOrDefaultAsync(specs, cancellationToken,false,false);
        if (response.Status is Status.Exception)
            return response.Exception!;
        if (response.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist;
        return response.Value;
    }
}
