namespace Application.Handlers.ScheduleHandlers.ScheduleItemHandlers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

using MediatR;

public record GetAllSItemsByScheduleIdHandler(IRepository Repository, IQClaims QClaims) : IQueryHandler<GetScheduleItemByScheduleDTO, IEnumerable<ScheduleItem>>
{
    async Task<QResult<IEnumerable<ScheduleItem>?>> IRequestHandler<QueryRequest<GetScheduleItemByScheduleDTO, IEnumerable<ScheduleItem>>, QResult<IEnumerable<ScheduleItem>?>>.Handle(QueryRequest<GetScheduleItemByScheduleDTO, IEnumerable<ScheduleItem>> request, CancellationToken cancellationToken)
    {
        return await Repository.GetAllAsync<ScheduleItem>(Specs.Common.GetByColumn<ScheduleItem>("DuringScheduleId", request.Request.ScheduleId), cancellationToken);
    }
}