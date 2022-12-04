namespace Application.Handlers.Commands.AccessConfigCommands;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.AccessConfigDTOs;
using Domain.Models.AccessConfigsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record UpdateAccessConfigHandler(IRepository Repository) : ICommandHandler<UpdateAccessConfigDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<UpdateAccessConfigDTO> request, CancellationToken cancellationToken)
    {
        var DBEntity = await Repository
            .FirstOrDefaultAsync(Specs.Common.GetByColumn<AccessConfig>("ConfigKey", request.Dto.ConfigKey!));
        if (DBEntity.Status == Status.Exception!)
            return DBEntity.Exception!;
        if (DBEntity.Value is null)
            return HandlerExceptions.AccessConfigExceptions.ConfigurationNotFound!;

        var AccessConfig = DBEntity.Value!;
        var response = await Repository.EnableChangeTracker(AccessConfig);
        if (response.Status == Status.Exception!)
            return response.Exception!;

        AccessConfig.Update(request.Dto);

        var saveChanges = await Repository.SaveChangesAsync(cancellationToken);
        if (saveChanges.Status == Status.Exception!)
            return saveChanges.Exception!;
        return response.Value!.Id!;
    }
}
