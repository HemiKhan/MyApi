namespace Application.Handlers.Commands.DoorGroupCommandHandlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.DoorGroupDtos;
using Domain.Models.CardFormatsModels;
using Domain.Models.DoorGroupModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal record UpdateDoorGroupHandler(IRepository Repository) : ICommandHandler<UpdateDoorGroupDto>
{
    public async Task<QResult<long?>> Handle(CommandRequest<UpdateDoorGroupDto> request, CancellationToken cancellationToken)
    {


        var oldDG = await Repository.FirstOrDefaultAsync(
           Specs.Common.GetByIdWithInclude<DoorGroup, DoorGroupDoors>(request.Dto.Id, _ => _.DoorGroupDoors), cancellationToken, true, false);

        if (oldDG.Status is Status.Exception)
            return oldDG.Exception!;
        //If parent not null

        if (oldDG.Value!.Name != request.Dto.Name)
        {
            var anyNameExist = await Repository.AnyAsync(Specs.Common.GetByColumn<DoorGroup>("Name", request.Dto.Name), cancellationToken, false, true);
            if (anyNameExist.Status is Status.Exception)
                return anyNameExist.Exception!;
        }
        var DoorGroup = oldDG.Value!;
        await Repository.EnableChangeTracker(DoorGroup);

        DoorGroup.Update(request.Dto);
        var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);
        if (qRepositoryAddResult.Status is Status.Exception)
            return qRepositoryAddResult.Exception!;
        return qRepositoryAddResult.Status is Status.Exception ? qRepositoryAddResult.Exception! : DoorGroup.Id;
    }
}
