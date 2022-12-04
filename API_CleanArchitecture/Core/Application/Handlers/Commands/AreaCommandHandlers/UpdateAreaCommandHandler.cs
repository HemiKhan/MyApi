namespace Application.Handlers.Commands.AreaCommandHandlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos;
using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record UpdateAreaCommandHandler(IRepository repo) : ICommandHandler<UpdateAreaDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<UpdateAreaDto>, QResult<long?>>.Handle(CommandRequest<UpdateAreaDto> request, CancellationToken cancellationToken)
    {
        var isIdExist = await repo.FirstOrDefaultAsync(
            Specs.Common.GetById<Area, long>(request.Dto.Id),
            cancellationToken, true, false);
        if (isIdExist.Status is Status.Exception)
            return isIdExist.Exception!;
        if (!request.Dto.Name.Equals(isIdExist.Value!.Name))
        {
            var nameExist = await repo.FirstOrDefaultAsync(
            Specs.Common.GetByColumn<Area>("Name", request.Dto.Name)
            , cancellationToken, false, true
            );
            if (nameExist.Status is Status.Exception)
                return nameExist.Exception!;
        }
        var areaEntityModel = isIdExist.Value!;
        await repo.EnableChangeTracker(areaEntityModel);
        areaEntityModel.Update(request.Dto);

        var addResult = await repo.SaveChangesAsync(cancellationToken);
        if (addResult.Status is Status.Exception)
            return addResult.Exception!;
        return addResult.Value!;
    }
}