namespace Application.Handlers.Queries.ManualControlQueryHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.ManualControlDtos;
using Domain.Models.ControllerModels.DoorModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record GetDoorDetailsByIdHandler(IRepository Repository) : IQueryHandler<long, GetDoorDetailsByIdDtoForManualControl>
{

    public async Task<QResult<GetDoorDetailsByIdDtoForManualControl?>> Handle(QueryRequest<long, GetDoorDetailsByIdDtoForManualControl> request, CancellationToken cancellationToken)
    {
        var specs = new GenericQSpec<Door, GetDoorDetailsByIdDtoForManualControl>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Id == request.Request)

            .Select(x => new GetDoorDetailsByIdDtoForManualControl(
                x.Id,
                x.Name,
                x.DoorType,
                x.State
                ))
        };
        var GetResult = await Repository.FirstOrDefaultAsync(specs, cancellationToken, true, false);
        return GetResult.Status is Status.Exception ? GetResult.Exception! : GetResult.Value;
    }
}
