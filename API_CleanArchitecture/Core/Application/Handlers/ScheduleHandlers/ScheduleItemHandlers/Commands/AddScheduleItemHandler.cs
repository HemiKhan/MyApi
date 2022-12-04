using Application.ExtensionMethods.Mappings.ScheduleMappings;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

using Serilog;

namespace Application.Handlers.ScheduleHandlers.Commands;
public record AddScheduleItemHandler(IRepository Repository, IQClaims QClaims, IRepository ScheduleRepo) : ICommandHandler<ScheduleItems_AddUpDate_Request>
{
    public async Task<QResult<long?>> Handle(CommandRequest<ScheduleItems_AddUpDate_Request> request, CancellationToken cancellationToken)
    {

        var getScheduleItemSpec = new GenericQSpec<ScheduleItem>()
        {
            SpecificationFunc = _ => _.Where(x => x.Id == request.Dto.Id)
        };
        //*********CHECK ID WHITHIN OGR IS EXIST IN DATABASE*************
        var Result = await ScheduleRepo.FirstOrDefaultAsync(
            Specs.Common.GetById<Schedule, long>(request.Dto.ScheduleId), cancellationToken, true, false);
        if (Result.Status is Status.Exception)
            throw Result.Exception!;
        if (request.Dto.Id > 0)
        {

            //***********CHECK ScheduleItem IS EXIST IN DATABASE**************
            var getDBItemResult = await Repository.FirstOrDefaultAsync(
                Specs.Common.GetById<ScheduleItem, long>(request.Dto.Id), cancellationToken, true, false);
            if (getDBItemResult.Status is Status.Exception)
                return QResults.From<long?>(getDBItemResult);

            if (request.Dto.Summary != getDBItemResult.Value!.Summary)
            {
                //*********CHECK Name WHITHIN OGR IS EXIST IN DATABASE*************
                var res = await Repository.AnyAsync(Specs.Common.GetByColumn<ScheduleItem>("Summary", request.Dto.Summary!), cancellationToken, false, true);
                if (res.Status is Status.Exception)
                    throw Result.Exception!;
            }

            var scheduleItem = getDBItemResult.Value!;
            await Repository.EnableChangeTracker(scheduleItem);

            scheduleItem.Update(request.Dto);

            var updateScheduleItemResult = await Repository.SaveChangesAsync(cancellationToken);
            return updateScheduleItemResult.Status is Status.Exception ? updateScheduleItemResult.Exception! : scheduleItem.Id; ;
        }
        else
        {
            //*********CHECK Name WHITHIN OGR IS EXIST IN DATABASE*************
            var scheduleItemSummaryAlreadyExist = Repository.AnyAsync(Specs.Common.GetByColumn<ScheduleItem>("Summary", request.Dto.Summary!), cancellationToken, false, true).Result;
            if (scheduleItemSummaryAlreadyExist.Status is Status.Exception)
                throw scheduleItemSummaryAlreadyExist.Exception!;
            var dbItem = ScheduleItem.Create(request.Dto);
            //***********ADDING IN DATABASE*****************
            var qRepositoryAddResult = await Repository.AddAsync(dbItem, cancellationToken);
            if (qRepositoryAddResult.Status == Status.Exception)
                throw qRepositoryAddResult.Exception!;
            return await Task.FromResult(qRepositoryAddResult.Value!.Id);
        }
    }
}