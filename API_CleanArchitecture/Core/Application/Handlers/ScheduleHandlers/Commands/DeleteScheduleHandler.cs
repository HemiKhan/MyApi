namespace Application.Handlers.ScheduleHandlers.Commands;
using Application.Common;
using Application.Constants;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Models.ScheduleModels;

using MediatR;

using Microsoft.EntityFrameworkCore;

internal record DeleteScheduleHandler(IRepository Repository, IQClaims QClaims, IRepository itemRepo) : ICommandHandler<DeleteScheduleDTO>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<DeleteScheduleDTO>, QResult<long?>>.Handle(CommandRequest<DeleteScheduleDTO> request, CancellationToken cancellationToken)
    {
        //CHECK ID WHITHIN OGR IS EXIST IN DATABASE
        var scheduleResult = await Repository.FirstOrDefaultAsync(
            Specs.Common.GetByIdWithInclude<Schedule, ScheduleItem>(request.Dto.Id, _ => _.ScheduleItems),
            cancellationToken, true, false);

        if (scheduleResult.Status is Status.Exception)
            return scheduleResult.Exception!;

        if (scheduleResult.Value!.ScheduleItems.Any())
        {
            // DELETING ALL SCHEDULE ITEMS
            foreach (var item in scheduleResult.Value!.ScheduleItems)
            {
                await itemRepo.DeleteAsync(item.Delete(), cancellationToken);
            }
        }

        // DELETING SCHEDULE
        var deleteResult = await Repository.DeleteAsync(
          scheduleResult.Value!.Delete(),
          cancellationToken);
        if (deleteResult.Status is Status.Exception)
            return deleteResult.Exception!;

        return await Task.FromResult(deleteResult.Value!.Id);
    }
}