namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services;
using Domain.Dtos.OutputSensorDTOs;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class OutputSensorController : QController
{
	private readonly IOutputSensorService _service;
	public OutputSensorController(IOutputSensorService service)
	{
		_service = service;
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());

		var getAllParams = new GetAllParams(search, currentPage, pageSize);
		return await _service.GetAllControllersAsync(getAllParams, cancellationToken);
	}
	//[HttpGet]
	//[Authorize]
	//[Route("{Id}")]
	//public async Task<ApiResponse> Get([AsParameters] long Id, CancellationToken cancellationToken = new())
	//{
	//	return await _service.GetDefaultIOPorts(Id, cancellationToken);
	//}
	[HttpPost]
	[Authorize]
	public async Task<ApiResponse> Add([FromBody] IEnumerable<Update_ControllerIoPorts_Dto> dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		if (!dto.Any())
			throw new ApiException($"Cannot insert empty list!");
		return await _service.AddUpdateControllerIoPortsAsync(dto, cancellationToken);
	}
}
