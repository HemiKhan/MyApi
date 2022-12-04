namespace Application.Handlers.Commands.AreaCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record DeleteAreaCommandHandler(IRepository repo) : ICommandHandler<long>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<long>, QResult<long?>>.Handle(CommandRequest<long> request, CancellationToken cancellationToken)
    {
        var oldRecord = await repo.FirstOrDefaultAsync(
            Specs.Common.GetById<Area, long>(request.Dto)
            , cancellationToken, true, false

            );
        if (oldRecord.Status is Status.Exception)
            return oldRecord.Exception!;
        var deleteResult = await repo.DeleteAsync(oldRecord.Value!.Delete(), cancellationToken);
        return deleteResult.Status is Status.Exception ? deleteResult.Exception! : deleteResult.Value!.Id;
    }
}
