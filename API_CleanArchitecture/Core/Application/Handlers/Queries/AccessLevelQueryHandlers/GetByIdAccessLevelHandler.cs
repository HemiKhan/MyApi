namespace Application.Handlers.Queries.AccessLevelQueryHandlers;

using Application.Common;
using Application.Handlers.Queries.ControllerQueriesHanlders.DoorQueryHandlers.RexQueryHandlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.AccessLevelSpecifications;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetByIdAccessLevelHandler(IRepository Repository) : IQueryHandler<long, GetById_AccessLevel_DTO>
{
    public async Task<QResult<GetById_AccessLevel_DTO?>> Handle(QueryRequest<long, GetById_AccessLevel_DTO> request, CancellationToken cancellationToken)
    {
        var response = await Repository.FirstOrDefaultAsync(AccessLevelSpecification.GetByIdAccessLevelSpecs(request.Request));
        return response.Status is Status.Exception ? response.Exception! : response.Value;
    }
}
