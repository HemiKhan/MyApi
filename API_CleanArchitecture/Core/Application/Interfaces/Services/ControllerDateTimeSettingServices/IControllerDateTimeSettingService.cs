namespace Application.Interfaces.Services.ControllerDateTimeSettingServices;

using Application.Handlers;
using Domain.Dtos.TimeZoneSettingDtos;

using AutoWrapper.Wrappers;

public interface IControllerDateTimeSettingService
{
    Task<ApiResponse> AddControllerDateTimeSetting(long ControllerId, CancellationToken cancellationToken);
    Task<ApiResponse> UpdateControllerDateTimeSetting(UpdateControllerDateTimeSettingDto dto, CancellationToken cancellationToken);
    Task<ApiResponse> GetControllerList(GetAllParams getAllParams, CancellationToken cancellationToken);
    Task<ApiResponse> GetById(long Id, CancellationToken cancellationToken);
}
