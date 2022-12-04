namespace Application.Handlers.Commands.AreaCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos;
using Domain.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AddAreaCommandHandler(IRepository repo) : ICommandHandler<AddAreaDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<AddAreaDto>, QResult<long?>>.Handle(CommandRequest<AddAreaDto> request, CancellationToken cancellationToken)
    {
        var nameExist = await repo.FirstOrDefaultAsync(
            Specs.Common.GetByColumn<Area>("Name", request.Dto.Name)
            , cancellationToken, false, true
            );
        if (nameExist.Status is Status.Exception)
            return nameExist.Exception!;
        var areaEntityModel = Area.Create(request.Dto);
        var addResult = await repo.AddAsync(areaEntityModel, cancellationToken);
        if (addResult.Status is Status.Exception)
            return addResult.Exception!;
        return addResult.Value!.Id;
    }
}
