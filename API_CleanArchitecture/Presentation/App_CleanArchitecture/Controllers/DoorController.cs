namespace App_CleanArchitecture.Controllers;
using Application.Handlers;
using Application.Interfaces.Services.DoorServices;
using Domain.Dtos.Door;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class DoorController : QController
{
    private readonly IDoorService _doorService;
    public DoorController(IDoorService doorService)
    {
        _doorService = doorService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ApiResponse> Add(Door_Add_DTO dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var response = await _doorService.AddAsync(dto, cancellationToken);
        return response;
    }

    [HttpGet]
    [Authorize]

    public async Task<ApiResponse> GetAll(string? search, int? currentPage, int? pageSize, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        GetAllParams param = new(search, currentPage, pageSize);
        var response = await _doorService.GetAllAsync(param, cancellationToken);
        return response;
    }

    [HttpGet]
    [Authorize]
    [Route("{Id}")]
    public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var response = await _doorService.GetAsync(Id, cancellationToken);
        return response;
    }

    [HttpPut]
    [Authorize]
    public async Task<ApiResponse> Update(Door_GetById_DTO dto, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var response = await _doorService.UpdateAsync(dto, cancellationToken);
        return response;
    }


    [HttpDelete]
    [Authorize]
    public async Task<ApiResponse> Remove(DeleteDoorDTO dto, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var response = await _doorService.DeleteAsync(dto, cancellationToken);
        return response;
    }
}
