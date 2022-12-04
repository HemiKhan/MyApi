using Application.ExtensionMethods.Mappings.ScheduleMappings;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.ScheduleHandlers.Commands;
internal record UpdateScheduleHandler(IRepository Repository, IQClaims QClaims) : ICommandHandler<UpdateScheduleDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<UpdateScheduleDTO> request, CancellationToken cancellationToken)
    {
        //CHECK ID WHITHIN OGR IS EXIST IN DATABASE
        var dbscheduleResultFromDB = await Repository.FirstOrDefaultAsync(
            Specs.Common.GetById<Schedule, long>(request.Dto.Id),
            cancellationToken);
        if (dbscheduleResultFromDB.Status is Status.Exception)
            return QResults.Exception<long?>(dbscheduleResultFromDB.Exception!);
        try
        {
            var dbSchedule = dbscheduleResultFromDB.Value!;
            await Repository.EnableChangeTracker(dbSchedule);

            dbSchedule!.Update(request.Dto);

            var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);

            return qRepositoryAddResult.Status is Status.Exception ? qRepositoryAddResult.Exception! : dbSchedule.Id;
        }
        catch (Exception ex)
        {

        }
        return default!;
    }
}
