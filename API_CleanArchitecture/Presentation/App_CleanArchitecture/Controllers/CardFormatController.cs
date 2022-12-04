namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.CardFormatServices;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class CardFormatController : QController
{
	private readonly ICardFormatService _service;
	public CardFormatController(ICardFormatService service)
	{
		_service = service;
	}

	[HttpPost]
	[Authorize]
	public async Task<ApiResponse> Add([FromBody] AddCardFormatDto dto, CancellationToken token = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.AddAsync(dto, token);
	}
	[HttpPut]
	[Authorize]
	public async Task<ApiResponse> Update([FromBody] UpdateCardFormatDto dto, CancellationToken token = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.UpdateAsync(dto, token);
	}
	[HttpGet]
	[Authorize]
	public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken token = new())
	{
		var getAllParams = new GetAllParams(search, currentPage, pageSize);
		return await _service.GetAllScrollAsync(getAllParams, token);
	}
	[HttpGet]
	[Authorize]
	[Route("{Id}")]
	public async Task<ApiResponse> Get(long Id, CancellationToken token = new())
	{
		return await _service.FirstOrDefaultAsync(Id, token);
	}

	[HttpDelete]
	[Authorize]
	public async Task<ApiResponse> Remove(DeleteCardFormatDto dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return await _service.DeleteAsync(dto, cancellationToken);
	}

}
