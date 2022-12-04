namespace Application.Handlers.Queries.AccessConfigsQueryHandlers;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.AccessConfigSpecsifications;
using Domain.Dtos.AccessConfigDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record GetByParentIdAccessConfigHandler(IRepository Repository) : IGetAllQueryHandler<GetByParentIdAccessConfigsDTO>
{
    public async Task<QResult<IEnumerable<GetByParentIdAccessConfigsDTO>?>> Handle(GetAllQueryRequest<GetByParentIdAccessConfigsDTO> request, CancellationToken cancellationToken)
    {
        var GetIdOfParent = await Repository.FirstOrDefaultAsync(AccessConfigSpecs
            .GetIdOfParentSpecs(request.GetAllParams.SearchValue!));
        if (GetIdOfParent.Status == Status.Exception!)
            return GetIdOfParent.Exception!;
        if (GetIdOfParent.Value is null)
            return HandlerExceptions.AccessConfigExceptions.ConfigurationNotFound!;

        var UpdatedParam = new GetAllParams(GetIdOfParent.Value.Id.ToString(), null, null);
        var response = await Repository
            .GetAllAsync(AccessConfigSpecs
            .GetByParentIdSpecs(UpdatedParam), cancellationToken, false, false);
        if (response.Value is null)
            return HandlerExceptions.AccessConfigExceptions.ConfigurationNotFound;

        return response.Status is Status.Exception ? response.Exception! : QResults.From( response.Value!);
    }
}
