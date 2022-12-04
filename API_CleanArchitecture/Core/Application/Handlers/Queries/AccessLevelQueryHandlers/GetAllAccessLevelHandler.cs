namespace Application.Handlers.Queries.AccessLevelQueryHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.AccessLevelSpecifications;
using Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetAllAccessLevelHandler(IRepository Repository) : IGetAllQueryHandler<GetAll_AccessLevel_DTO>
{
    public async Task<QResult<IEnumerable<GetAll_AccessLevel_DTO>?>> Handle(GetAllQueryRequest<GetAll_AccessLevel_DTO> request, CancellationToken cancellationToken)
    {
        var GetAllResponse = await Repository.GetAllAsync(
    AccessLevelSpecification.GetAllAccessLevelSpecs(request.GetAllParams));

        return GetAllResponse.Status == Status.Exception ? GetAllResponse.Exception! : QResults.From( GetAllResponse.Value!);
    }
}
