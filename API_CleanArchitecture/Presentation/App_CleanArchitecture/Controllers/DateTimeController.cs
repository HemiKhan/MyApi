namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.ControllerDateTimeSettingServices;
using Domain.Dtos.TimeZoneSettingDtos;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class DateTimeController : QController
{
	private readonly IControllerDateTimeSettingService _service;
	public DateTimeController(IControllerDateTimeSettingService service)
	{
		_service = service;
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken token = new())
	{
		var getAllParams = new GetAllParams(search, currentPage, pageSize);
		var list = await _service.GetControllerList(getAllParams, token);
		return list;
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetById(long id, CancellationToken token = new())
	{
		var list = await _service.GetById(id, token);
		return list;
	}
	[HttpPut]
	[Authorize]
	public async Task<ApiResponse> Update(UpdateControllerDateTimeSettingDto dto, CancellationToken token = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		var response = await _service.UpdateControllerDateTimeSetting(dto, token);
		return response;
	}
}
