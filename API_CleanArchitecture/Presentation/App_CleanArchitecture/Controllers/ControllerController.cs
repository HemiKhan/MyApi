namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services;
using Domain.Dtos.ControllerDTOs;

using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class ControllerController : QController
{
    private readonly IControllerService _controllerService;

    public ControllerController(IControllerService controllerService)
    {
        _controllerService = controllerService;
    }


    [HttpPost]
    [Authorize]

    public async Task<ApiResponse> Add(AddControllerCommand addDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _controllerService.AddAsync(addDTO, cancellationToken);
        return serviceResult;
    }


    [HttpPut]
    [Authorize]
    public async Task<ApiResponse> Update(Update_ControllerDTO updateDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _controllerService.UpdateAsync(updateDTO, cancellationToken);
        return serviceResult;
    }



    [HttpDelete]
    [Authorize]
    public async Task<ApiResponse> Remove(Delete_ControllerDTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return await _controllerService.DeleteAsync(dto, cancellationToken);
    }


    [HttpGet]
    [Authorize]

    public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());

        var getAllParams = new GetAllParams(search, currentPage, pageSize);
        return await _controllerService.GetAllAsync(getAllParams, cancellationToken);

    }

    [Authorize]
    [HttpGet]
    [Route("{Id}")]

    public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return await _controllerService.GetAsync(Id, cancellationToken);
    }

    [Authorize]
    [HttpGet]
    [Route("{Id}")]
    public async Task<ApiResponse> GetDoor(long Id, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return await _controllerService.GetDoorByControllerIdAsync(Id, cancellationToken);
    }
}
