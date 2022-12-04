namespace Application.Interfaces.Repositories;
using System.Collections.Generic;

using Application.Handlers;
using Domain.Dtos;
using Domain.Dtos.TimeZoneSettingDtos;

public interface IScheduleRepository
{
    QResult<IEnumerable<GetControllersListForDateTimeSetting>?> ControllerList(GetAllParams getAllParams, CancellationToken cancellationToken = default);
}
