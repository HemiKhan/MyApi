namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.PrioritiesServices;
using Domain.Dtos.PrioritiesDTOs;
using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using AutoWrapper.Wrappers;

public class PrioritiesController : QController
{
	private readonly IPrioritiesServices _prioritiesServices;
	public PrioritiesController(IPrioritiesServices prioritiesServices)
	{
		_prioritiesServices = prioritiesServices;
	}

	[HttpGet]
    [Authorize]
    public Task<ApiResponse> GetAll(string search, int? currentPage, int? pageSize, CancellationToken cancellationToken = new())
	{
		var param = new GetAllParams(search, currentPage, pageSize);
		return _prioritiesServices.GetAll(param, cancellationToken);
	}


	[HttpGet]
    [Authorize]
    [Route("{Id}")]
    public Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return _prioritiesServices.Get(Id, cancellationToken);
	}
    [Authorize]
    [HttpPost]
	public Task<ApiResponse> Add(AddPriorityDTO dto, CancellationToken cancellationToken = new())
	{
		if (!ModelState.IsValid)
			throw new ApiException(ModelState.AllErrors());
		return _prioritiesServices.AddAsync(dto, cancellationToken);
	}

	[HttpPut]
    [Authorize]
    public Task<ApiResponse> Update(Update_PriorityDTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return _prioritiesServices.UpdateAsync(dto, cancellationToken);
    }

    [HttpDelete]
    [Authorize]
    public Task<ApiResponse> Remove(DeletePriorityDTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return _prioritiesServices.DeleteAsync(dto, cancellationToken);
    }
}
