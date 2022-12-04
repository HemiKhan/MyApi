namespace Application.Handlers.ControllerDateTimeSettingHandlers.Queries;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.TimeZoneModels;

public record GetControllerListHandler(IRepository Repository, IScheduleRepository ScheduleRepository, IQClaims QClaims) : IGetAllQueryHandler<GetControllersListForDateTimeSetting>
{
    public async Task<QResult<IEnumerable<GetControllersListForDateTimeSetting>?>> Handle(GetAllQueryRequest<GetControllersListForDateTimeSetting> request, CancellationToken cancellationToken)
    {
        var getListSpecs = new GenericQSpec<ControllerDateTime>()
        {
            SpecificationFunc = _ => _.WhereOrgId(QClaims.OrganizationId)
        };
        var getAllControllerResult = ScheduleRepository.ControllerList(request.GetAllParams, cancellationToken);
        return getAllControllerResult;
    }
}