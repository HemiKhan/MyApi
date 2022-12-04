namespace Application.Handlers.Commands.DoorGroupCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.DoorGroupDtos;
using Domain.Models.DoorGroupModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

internal record AddDoorGroupHandler(IRepository Repository) : ICommandHandler<AddDoorGroupDto>
{
    public async Task<QResult<long?>> Handle(CommandRequest<AddDoorGroupDto> request, CancellationToken cancellationToken)
    {

        var IsNameAlreadyExist = await Repository.AnyAsync(Specs.Common.GetByColumn<DoorGroup>("Name", request.Dto.Name), cancellationToken, false, true);
        if (IsNameAlreadyExist.Status is Status.Exception)
            return IsNameAlreadyExist.Exception!;
        var dbEntity = DoorGroup.Create(request.Dto);
        var DGAddRepoResult = await Repository.AddAsync(dbEntity, cancellationToken, true);
        if (DGAddRepoResult.Status is Status.Exception) return DGAddRepoResult.Exception!;
        var DGDEntity = new List<DoorGroupDoors>();
        foreach (var DoorId in request.Dto.DoorId)
        {
            DGDEntity.Add(DoorGroupDoors.Create(dbEntity.Id, DoorId));
        }
        var DGDAddRepoResult = await Repository.AddRangeAsync(DGDEntity, cancellationToken, true);
        if (DGDAddRepoResult.Status is Status.Exception)
        {
            var DGDeleteRepoResult = await Repository.DeleteAsync(
         DGAddRepoResult.Value!.Delete(),
         cancellationToken);
        }
        return DGAddRepoResult.Value!.Id;
    }
}
