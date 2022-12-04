namespace Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers.RexQueryHandlers;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;

public record GetAllRexHandler() : IGetAllQueryHandler<Rex_GetById_DTO>
{
    public Task<QResult<IEnumerable<Rex_GetById_DTO>?>> Handle(GetAllQueryRequest<Rex_GetById_DTO> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
