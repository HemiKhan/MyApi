namespace Application.Handlers.ControllerHandlers.Commands.ControllerCommands;

using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Dtos.ControllerDTOs;

using MediatR;

internal record UpdateControllerHandler(IRepository Repository, IQClaims QClaims) : ICommandHandler<Update_ControllerDTO>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<Update_ControllerDTO>, QResult<long?>>.Handle(CommandRequest<Update_ControllerDTO> request, CancellationToken cancellationToken)
    {


        var hasException = await Repository.AnyAsync(
           Specifications.Specs.ControllerSpecs.CheckNameAlreadyExists(request.Dto.Id, request.Dto.Name),
            cancellationToken, false, true);

        if (hasException.Status is Status.Exception)
            return hasException.Exception!;


        var controllerModelResult = await Repository.FirstOrDefaultAsync(
Specifications.Specs.Common.GetById<Domain.Models.ControllerModels.Controller, long>(request.Dto.Id),
                cancellationToken);

        if (controllerModelResult.Status is Status.Exception)
            return controllerModelResult.Exception!;

        var controller = controllerModelResult.Value!;
        await Repository.EnableChangeTracker(controller);

        controller.Update(request.Dto);

        var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);

        if (qRepositoryAddResult.Status is Status.Exception)
            return qRepositoryAddResult.Exception!;

        return await Task.FromResult(controller.Id);
    }
}
