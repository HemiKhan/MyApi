namespace Application.Handlers.ScheduleHandlers.ScheduleItemHandlers.Queries;

using System.Linq;
using System.Threading.Tasks;

using Application.ExtensionMethods.Mappings.ScheduleMappings;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

using Microsoft.EntityFrameworkCore;

public record GetItemsByIdHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<GetScheduleItemByIdDTO, GetScheduleItemDTO>
{
    public async Task<QResult<GetScheduleItemDTO?>> Handle(QueryRequest<GetScheduleItemByIdDTO, GetScheduleItemDTO> request, CancellationToken cancellationToken)
    {

        var getAllSpec = new GenericQSpec<ScheduleItem>()
        {
            SpecificationFunc = _ => _.Where(_ => _.Id == request.Request.Id).Include(_ => _.Schedules),
        };
        var result = await Repository.FirstOrDefaultAsync(getAllSpec, cancellationToken, false);
        if (result.Status is Status.Exception)
            throw result.Exception!;
        if (result.Status is Status.NotFound)
            throw result.Exception!;
        var convertedresult = ScheduleItemDtoExtensionMethods.AsDomainModel(result.Value!);
        return convertedresult;


    }
}

