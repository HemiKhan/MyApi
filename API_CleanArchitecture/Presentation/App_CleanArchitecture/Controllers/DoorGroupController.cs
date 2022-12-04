namespace App_CleanArchitecture.Controllers;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.DoorServices;
using Domain.Dtos.DoorGroupDtos;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Mvc;

using System.Configuration;
using AutoWrapper.Wrappers;

public class DoorGroupController : QController
{
	private readonly IDoorGroupService _service;
	public DoorGroupController(IDoorGroupService doorGroupService)
	{
		_service = doorGroupService;
	}
	[HttpGet]
	[Route("{Id}")]
	public async Task<ApiResponse> Get(int Id, CancellationToken cancellationToken = new())
	{
		return await _service.GetByIdAsync(Id, cancellationToken);
	}
	[HttpGet]

	public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());

		var getAllParams = new GetAllParams(search, currentPage, pageSize);
		return await _service.GetAllAsync(getAllParams, cancellationToken);
	}
	[HttpPost]
	public async Task<ApiResponse> Add([FromBody] AddDoorGroupDto Dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.AddAsync(Dto, cancellationToken);
	}
	[HttpPut]
	public async Task<ApiResponse> Update([FromBody] UpdateDoorGroupDto Dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.UpdateAsync(Dto, cancellationToken);
	}
	[HttpDelete]
	public async Task<ApiResponse> Remove(long Id, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.DeleteAsync(Id, cancellationToken);
	}
}
