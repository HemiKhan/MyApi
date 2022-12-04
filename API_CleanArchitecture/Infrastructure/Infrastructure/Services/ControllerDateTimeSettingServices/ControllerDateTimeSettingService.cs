namespace Infrastructure.Services.ControllerDateTimeSettingServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.ControllerDateTimeSettingServices;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Exceptions;
using Domain.Models.ControllerModels;
using Domain.Models.TimeZoneModels;

using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;


using System.Net;
using System.Threading;
using System.Threading.Tasks;

public record ControllerDateTimeSettingService(IQSender sender, IQClaims claims) : IControllerDateTimeSettingService
{
	async Task<ApiResponse> IControllerDateTimeSettingService.UpdateControllerDateTimeSetting(UpdateControllerDateTimeSettingDto dto, CancellationToken cancellationToken)
	{
		var result = await sender.Send(new QueryRequest<long, bool>(dto.ControllerId));
		if (result.Status is Status.Exception)
			throw result.Exception!;
		if (dto.SetMode is Domain.Constants.SetMode.NTP)
		{
			IPAddress ip;
			bool ValidateIP = IPAddress.TryParse(dto.IPAddress, out ip!);
			if (!ValidateIP)
				throw new QException("Ip is no valid");
		}
		if (dto.SetMode is Domain.Constants.SetMode.Manual)
		{
			var Date = dto.Date!.Substring(dto.Date.Length - 4);
			if (Date.ToInt32() < 1970 || Date.ToInt32() > 2037)
				throw new QException("Date must be greater thand 1970 and less than 2037");
		}
		if (dto.SetMode is Domain.Constants.SetMode.System)
		{
			dto.Date = DateTime.UtcNow.ToString("MM-dd-yyyy");
			dto.Time = DateTime.Now.ToString("h:mm:ss");
		}
		var reponse = await UpdateControllerDateTimeSetting(dto, cancellationToken);
		return reponse.Result!;

	}

	private async Task<QResult<long?>> UpdateControllerDateTimeSetting(UpdateControllerDateTimeSettingDto settingDto, CancellationToken token)
	{
		if (settingDto.SettingForAllController)
		{
			QResult<long?>? updateResult = 0; ;
			var result = await sender.Send(new QueryRequest<List<ControllerDateTime>>(), token);
			if (result.Value.Count > 0)
			{
				foreach (var item in result.Value!)
				{
					UpdateControllerDateTimeSettingDto update = new UpdateControllerDateTimeSettingDto
					{
						ControllerId = item.ControllerId,
						TimeZoneValue = settingDto.TimeZoneValue,
						DayLightSaving = settingDto.DayLightSaving,
						SetMode = settingDto.SetMode,
						DHCP = settingDto.DHCP,
						IPAddress = settingDto.IPAddress,
						Date = settingDto.Date,
						Time = settingDto.Time,
						SettingForAllController = settingDto.SettingForAllController
					};
					updateResult = await UpdateDateTimeSettingInDb(update);
				}
			}
			return updateResult;

		}
		else
		{
			return await UpdateDateTimeSettingInDb(settingDto);
		}
	}

	private async Task<QResult<long?>> UpdateDateTimeSettingInDb(UpdateControllerDateTimeSettingDto settingDto)
	{
		return await sender.Send(new CommandRequest<UpdateControllerDateTimeSettingDto>(settingDto));

	}

	public async Task<ApiResponse> GetControllerList(GetAllParams getAllParams, CancellationToken cancellationToken)
	{
		var list = await sender.Send(new GetAllQueryRequest<GetControllersListForDateTimeSetting>(getAllParams));
		return list.Result;

	}
	public async Task<ApiResponse> GetById(long Id, CancellationToken cancellationToken)
	{
		var result = await sender.Send(new QueryRequest<long, GetByIdDateTimeSettingDto>(Id), cancellationToken);
		return result.Result!;
	}

	public async Task<ApiResponse> AddControllerDateTimeSetting(long ControllerId, CancellationToken cancellationToken)
	{
		var result = await sender.Send(new QueryRequest<long, bool>(ControllerId));
		if (result.Status is Status.Exception)
			throw result.Exception!;
		var dto = new AddControllerDateTimeSettingDto()
		{
			ControllerId = ControllerId,
			TimeZoneValue = claims.TimeZone,
			DayLightSaving = false,
			IPAddress = null,
			DHCP = null,
			Date = null,
			Time = null,
			SetMode = Domain.Constants.SetMode.System
		};
		var addResult = await sender.Send(new CommandRequest<AddControllerDateTimeSettingDto>(dto), cancellationToken);
		if (addResult.Status == Status.Exception)
			throw addResult.Exception!;
		return addResult.Result!;
	}
}
