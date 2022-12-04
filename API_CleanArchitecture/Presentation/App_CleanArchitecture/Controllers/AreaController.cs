namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services;
using Domain.Dtos;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class AreaController : QController
{
	private readonly IAreaService _areaService;
	public AreaController(IAreaService areaService)
	{
		_areaService = areaService;
	}
	[HttpPost]
	[Authorize]
	public async Task<ApiResponse> Add(AddAreaDto dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _areaService.AddAsync(dto, cancellationToken);
	}
	[HttpPut]
	[Authorize]
	public async Task<ApiResponse> Update(UpdateAreaDto dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _areaService.UpdateAsync(dto, cancellationToken);
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetById(long Id, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _areaService.GetById(Id, cancellationToken);
	}
	[HttpDelete]
	[Authorize]
	public async Task<ApiResponse> Remove(long Id, CancellationToken cancellationToken = new())
	{
		return await _areaService.DeleteAsync(Id, cancellationToken);
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());

		var getAllParams = new GetAllParams(search, currentPage, pageSize);
		return await _areaService.GetAllAsync(getAllParams, cancellationToken);
	}
}
