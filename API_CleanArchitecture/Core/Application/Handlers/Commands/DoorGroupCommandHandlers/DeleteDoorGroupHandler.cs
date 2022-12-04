namespace Application.Handlers.Commands.DoorGroupCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Models.DoorGroupModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record DeleteDoorGroupHandler(IRepository Repository) : ICommandHandler<long, long>
{
    public async Task<QResult<long>> Handle(CommandRequest<long, long> request, CancellationToken cancellationToken)
    {
        var OldDbEntity = await Repository.FirstOrDefaultAsync(Specs.Common.GetById<DoorGroup, long>(request.Dto), cancellationToken, true, false);
        if (OldDbEntity.Status is Status.Exception)
            return OldDbEntity.Exception!;
        var deleteResult = await Repository.DeleteAsync(OldDbEntity.Value!.Delete(), cancellationToken);
        if (deleteResult.Status is Status.Exception)
            return deleteResult.Exception!;
        return OldDbEntity.Value!.Id;
    }
}
