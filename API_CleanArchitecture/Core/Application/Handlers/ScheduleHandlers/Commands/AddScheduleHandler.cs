namespace Application.Handlers.ScheduleHandlers.Commands;
using Application.Common;
using Application.Constants;
using Application.ExtensionMethods.Mappings.ScheduleMappings;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Models.ControllerModels;
using Domain.Models.ScheduleModels;

public record AddScheduleHandler(IRepository Repository, IRepository controllerRepo, IQClaims QClaims) : ICommandHandler<AddScheduleDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<AddScheduleDTO> request, CancellationToken cancellationToken)
    {
        //CHECK IF ANY CONTROLLER WHITHIN OGR IS EXIST
        var ControllerResult = await controllerRepo.AnyAsync<Controller>(cancellationToken, true, false);
        if (ControllerResult.Status is Status.Exception)
            return QResults.InfoMessage<long?>(default, "Controller not exist please add first!");

        var scheduleResult = await Repository.AnyAsync(
            Specs.Common.GetByColumn<Schedule>("Name", request.Dto.Name),
            cancellationToken, false, true);

        if (scheduleResult.Status is Status.Exception)
            return scheduleResult.Exception!;

        var schedule = Schedule.Create(request.Dto);
        Serilog.Log.Verbose(Repository.DbContext.ChangeTracker.DebugView.LongView);
        var qRepositoryAddResult = await Repository.AddAsync(schedule);
        if (qRepositoryAddResult.Status == Status.Exception)
            return qRepositoryAddResult.Exception!;
        return qRepositoryAddResult.Value!.Id;
    }
}