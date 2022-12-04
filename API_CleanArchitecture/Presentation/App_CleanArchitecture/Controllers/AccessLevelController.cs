namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.AccessLevelServices;
using Domain.Dtos.AccessLevelDTOs;
using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class AccessLevelController : QController
{
	private readonly IAccessLevelService Service;
	public AccessLevelController(IAccessLevelService service)
	{
			Service = service;
	}


    [Authorize]
	[HttpGet]
	public async Task<ApiResponse> GetAll(string search, int? currentPage, int? pageSize, CancellationToken cancellationToken = new())
	{
        //if (!ModelState.IsValid)
        //    throw new ApiException(ModelState.AllErrors());
        var getAllparams = new GetAllParams(search, currentPage, pageSize);
        return await Service.GetAllAsync(getAllparams);
	}


    [Authorize]
    [HttpGet]
    [Route("{Id}")]
    public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(errors: ModelState.AllErrors());
        return await Service.GetByIdAsync(Id,cancellationToken);
    }


    [Authorize]
    [HttpPost]
    public async Task<ApiResponse> Add(Add_AccessLevel_DTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(errors: ModelState.AllErrors());
        return await Service.AddAsync(dto);
    }

    [Authorize]
    [HttpPut]
    public async Task<ApiResponse> Update(Update_AccessLevel_DTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(errors: ModelState.AllErrors());
        return await Service.UpdateAsync(dto);
    }

    [Authorize]
    [HttpDelete]
    public async Task<ApiResponse> Remove(Delete_AccessLevel_DTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(errors: ModelState.AllErrors());
        return await Service.DeleteAsync(dto);
    }

}
