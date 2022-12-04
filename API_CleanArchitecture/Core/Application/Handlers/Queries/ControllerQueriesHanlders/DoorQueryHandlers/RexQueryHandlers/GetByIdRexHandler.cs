namespace Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers.RexQueryHandlers;

using Application.Common;
using Application.Interfaces;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetByIdRexHandler() : IQueryHandler<long, Rex_GetById_DTO>
{
    public Task<QResult<Rex_GetById_DTO?>> Handle(QueryRequest<long, Rex_GetById_DTO> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
