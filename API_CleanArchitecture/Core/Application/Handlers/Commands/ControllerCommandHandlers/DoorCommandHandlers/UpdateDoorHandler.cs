namespace Application.Handlers.Commands.ControllerCommandHandlers.DoorCommandHandlers;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.Door;
using System.Threading;
using System.Threading.Tasks;

public record UpdateDoorHandler(IRepository Repository) : ICommandHandler<Door_GetById_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Door_GetById_DTO> request, CancellationToken cancellationToken)
    {
        var doorRepositoryResult = await Repository.FirstOrDefaultAsync(
         Specs.DoorSpecs.GetDoor(request.Dto.Id),
          cancellationToken);

        if (doorRepositoryResult.Status is Status.Exception)
            return doorRepositoryResult.Exception!;

        try
        {
            var door = doorRepositoryResult.Value!;
            await Repository.EnableChangeTracker(door);

            door!.UpdateDoor(request.Dto);

            var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);

            if (qRepositoryAddResult.Status is Status.Exception)
                return qRepositoryAddResult.Exception!;

            return qRepositoryAddResult.Status is Status.Exception ? qRepositoryAddResult.Exception! : door.Id;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return default!;

    }
}
