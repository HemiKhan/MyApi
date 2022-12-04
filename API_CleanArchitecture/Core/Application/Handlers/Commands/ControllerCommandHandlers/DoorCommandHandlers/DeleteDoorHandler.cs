namespace Application.Handlers.Commands.ControllerCommandHandlers.DoorCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.Door;
using Domain.Models.ControllerModels;
using Domain.Models.ControllerModels.DoorModels;
using System.Threading;
using System.Threading.Tasks;

internal record DeleteDoorHandler(IRepository Repository) : ICommandHandler<DeleteDoorDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<DeleteDoorDTO> request, CancellationToken cancellationToken)
    {
        var repositoryResult = await Repository
            .FirstOrDefaultAsync(Specs.DoorSpecs.GetDoor(request.Dto.Id));
        if (repositoryResult.Status is Status.Exception)
            return repositoryResult.Exception!;

        var door = repositoryResult.Value;

        QResult<Controller?>? getDoorController = await Repository.FirstOrDefaultAsync(
        Specs.Common.GetByIdWithInclude<Controller, Door>(door.ControllerId, _ => _.Doors),
        cancellationToken);

        if (getDoorController.Status is Status.Exception)
            return getDoorController.Exception!;

        var controlller = getDoorController.Value;
        await Repository.EnableChangeTracker(controlller);
        controlller!.RemoveDoor(door);

        //var door = request.Dto.AsDomainModel();
        var response = await Repository.SaveChangesAsync(cancellationToken);
        if (response.Status is Status.Exception)
            return response.Exception!;
        return door.Id;
    }
}
