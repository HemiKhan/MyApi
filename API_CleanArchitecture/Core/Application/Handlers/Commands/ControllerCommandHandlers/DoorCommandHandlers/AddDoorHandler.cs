namespace Application.Handlers.Commands.ControllerCommandHandlers.DoorCommandHandlers;

using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.Door;
using Domain.Models.ControllerModels;
using Domain.Models.ControllerModels.DoorModels;

public record AddDoorHandler(IRepository Repository) : ICommandHandler<Door_Add_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Door_Add_DTO> request, CancellationToken cancellationToken)
    {
        QResult<Controller?>? getControllerByIdResult = await Repository.FirstOrDefaultAsync(
        Specs.Common.GetByIdWithInclude<Controller, Door>(request.Dto.ControllerId, _ => _.Doors),
        cancellationToken);

        if (getControllerByIdResult.Status is Status.Exception)
            return getControllerByIdResult.Exception!;

        try
        {
            var controller = getControllerByIdResult.Value!;
            await Repository.EnableChangeTracker(controller);
            controller!.AddDoor(request.Dto);

            var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);

            return qRepositoryAddResult.Status is Status.Exception ? qRepositoryAddResult.Exception! : controller.Id;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
