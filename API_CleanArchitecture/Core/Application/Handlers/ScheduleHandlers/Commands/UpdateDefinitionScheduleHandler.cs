namespace Application.Handlers.ScheduleHandlers.Commands;

using System.Linq;
using System.Threading.Tasks;

using Application.ExtensionMethods.Mappings.ScheduleMappings;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore;

public record UpdateDefinitionScheduleHandler(IRepository Repository, IQClaims QClaims) : ICommandHandler<UpdateScheduleDefinitionDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<UpdateScheduleDefinitionDTO> request, CancellationToken cancellationToken)
    {
        //CHECK ID WHITHIN OGR IS EXIST IN DATABASE
        var scheduleResult = Repository.FirstOrDefaultAsync(
            Specs.Common.GetById<Schedule, long>(request.Dto.ScheduleId),
            cancellationToken).Result;

        if (scheduleResult.Status is Status.Exception)
            return QResults.From<long?>(scheduleResult);
        try
        {
            var oldScheduleDbResult = scheduleResult.Value!;
            await Repository.EnableChangeTracker(oldScheduleDbResult);

            oldScheduleDbResult!.UpdateDefinitionOnly(request.Dto);

            var qRepositoryAddResult = await Repository.SaveChangesAsync(cancellationToken);

            return qRepositoryAddResult.Status is Status.Exception ? qRepositoryAddResult.Exception! : oldScheduleDbResult.Id;
        }
        catch (Exception ex)
        {

        }
        return default!;
    }
}