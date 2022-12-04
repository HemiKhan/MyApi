using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.ScheduleHandlers.ScheduleItemHandlers.Commands;

public record DeleteScheduleItemHandler(IRepository Repository, IQClaims QClaims) : ICommandHandler<DeleteScheduleItemDto>
{
    public async Task<QResult<long?>> Handle(CommandRequest<DeleteScheduleItemDto> request, CancellationToken cancellationToken)
    {
        //CHECK ID WHITHIN OGR IS EXIST IN DATABASE
        var scheduleResult = await Repository.FirstOrDefaultAsync(Specs.Common.GetById<ScheduleItem, long>(request.Dto.Id), cancellationToken, true, false);

        if (scheduleResult.Status is Status.Exception)
            throw scheduleResult.Exception!;
        if (scheduleResult.Value is null)
            return QResults.NotFound<long?>(HandlerMessages.ScheduleItemHanderMessages.NotFound);

        var deleteResult = await Repository.DeleteAsync(scheduleResult.Value.Delete(), cancellationToken);
        if (deleteResult.Status is Status.Exception)
            throw deleteResult.Exception!;
        return await Task.FromResult(deleteResult.Value!.Id);
    }
}