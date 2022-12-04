namespace Application.Handlers.Queries.AccessConfigsQueryHandlers;

using Application.Common;
using Application.Exceptions;
using Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers.RexQueryHandlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.AccessConfigSpecsifications;
using Domain.Dtos.AccessConfigDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetByConfigKeyHandler(IRepository Repository) : IQueryHandler<GetByConfigKey_AccessConfig_Request, GetByConfigKey_AccessConfigsDTO>
{
    public async Task<QResult<GetByConfigKey_AccessConfigsDTO?>> Handle(QueryRequest<GetByConfigKey_AccessConfig_Request, GetByConfigKey_AccessConfigsDTO> request, CancellationToken cancellationToken)
    {
        var response = await Repository
            .FirstOrDefaultAsync(AccessConfigSpecs
            .GetByConfigKeySpecs(request.Request.ConfigKey!),cancellationToken, false, false);

        if (response.Value is null)
            return HandlerExceptions.AccessConfigExceptions.AccessConfigKeyDoesNotExist;

        return response.Status is Status.Exception ? response.Exception! : response.Value!;
    }
}
