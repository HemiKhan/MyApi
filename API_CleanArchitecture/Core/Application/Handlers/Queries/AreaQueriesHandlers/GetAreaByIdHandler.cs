namespace Application.Handlers.Queries.AreaQueriesHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Models;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

internal record GetAreaByIdHandler(IRepository repo) : IQueryHandler<long, GetAreaByIdDto>
{
    async Task<QResult<GetAreaByIdDto?>> IRequestHandler<QueryRequest<long, GetAreaByIdDto>, QResult<GetAreaByIdDto?>>.Handle(QueryRequest<long, GetAreaByIdDto> request, CancellationToken cancellationToken)
    {

        var specs = new GenericQSpec<Area, GetAreaByIdDto>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Id == request.Request)
            .Select(_ => new GetAreaByIdDto(_.Id, _.Name, _.IsEntrance))
        };
        var repoResult = await repo.FirstOrDefaultAsync(specs,
              cancellationToken, true, false
              );
        if (repoResult.Status is Status.Exception)
            return repoResult.Exception!;
        return repoResult.Value;
    }
}
