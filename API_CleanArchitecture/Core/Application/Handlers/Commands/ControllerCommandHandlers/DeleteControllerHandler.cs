namespace Application.Handlers.ControllerHandlers.Commands.Controller;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.ControllerDTOs;
using Domain.Models.ControllerModels;

using MediatR;

internal record DeleteControllerHandler(IQClaims QClaims, IRepository Repository) : ICommandHandler<Delete_ControllerDTO>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<Delete_ControllerDTO>, QResult<long?>>.Handle(CommandRequest<Delete_ControllerDTO> request, CancellationToken cancellationToken)
    {
        var controller = await Repository.FirstOrDefaultAsync(
            Specs.Common.GetById<Controller, long>(request.Dto.Id), cancellationToken: cancellationToken);
        if (controller.Status is Status.Exception)
            return controller.Exception!;

        QResult<Controller?>? reponse = await Repository.DeleteAsync(controller!.Value!.Delete(), cancellationToken: cancellationToken);

        return reponse.Status is Status.Exception ? reponse.Exception! : reponse.Value!.Id;
    }
}
