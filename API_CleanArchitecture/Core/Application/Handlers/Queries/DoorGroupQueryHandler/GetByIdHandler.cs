namespace Application.Handlers.Queries.DoorGroupQueryHandler;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.DoorGroupDtos;
using Domain.Models.DoorGroupModels;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


internal record GetByIdDoorGroupHandler(IRepository repo) : IQueryHandler<long, GetByIdDoorGroupDto>
{

    public async Task<QResult<GetByIdDoorGroupDto?>> Handle(QueryRequest<long, GetByIdDoorGroupDto> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<DoorGroup, GetByIdDoorGroupDto>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Id.Equals(request.Request))
            .Select(_ => new GetByIdDoorGroupDto(_.Id, _.Name,
            _.DoorGroupDoors.Select(_ => new DGDDto(_.Id, _.DoorId))))

        };
        var repoResult = await repo.FirstOrDefaultAsync(specs, cancellationToken, true, false);

        return repoResult.Status is Status.Exception ? repoResult.Exception! : repoResult.Value;
    }
}
