namespace Application.Handlers.ControllerHandlers.Commands.Controller;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.ControllerDTOs;
using Domain.Models.ControllerModels;

using MediatR;

internal record AddControllerHandler(IRepository Repository) : ICommandHandler<AddControllerCommand>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<AddControllerCommand>, QResult<long?>>.Handle(CommandRequest<AddControllerCommand> request, CancellationToken cancellationToken)
    {


        var controllerExistResult = await Repository.AnyAsync(
            Specs.Common.GetByColumn<Controller>(ModelFields.CommonFields.Name, request.Dto.Name),
             cancellationToken, false, true);

        if (controllerExistResult.Status is Status.Exception)
            return controllerExistResult.Exception!;

        var controller = Controller.Create(request.Dto);
        Serilog.Log.Verbose(Repository.DbContext.ChangeTracker.DebugView.LongView);
        var qRepositoryAddResult = await Repository.AddAsync(controller);
        if (qRepositoryAddResult.Status == Status.Exception)
            return qRepositoryAddResult.Exception!;
        return qRepositoryAddResult.Value!.Id;
    }
}
