namespace Application.Handlers.CommanHandler;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Models.ControllerModels;

using MediatR;

public record AnyControllerExistHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<long, bool>
{
    async Task<QResult<bool>> IRequestHandler<QueryRequest<long, bool>, QResult<bool>>.Handle(QueryRequest<long, bool> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<Controller>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Id == request.Request)
        };
        var result = await Repository.AnyAsync(specs, cancellationToken);
        return result.Value!;
    }
}