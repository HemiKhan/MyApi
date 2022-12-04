namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.ScheduleServices;
using Domain.Dtos;
using Domain.Dtos.Schedule.ScheduleItemsDtos;

using AutoWrapper.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class ScheduleController : QController
{
    private readonly IScheduleService _scheduleService;
    private readonly IScheduleItemService _scheduleItemService;

    public ScheduleController(IScheduleService scheduleService, IScheduleItemService scheduleItemService)
    {
        _scheduleService = scheduleService;
        _scheduleItemService = scheduleItemService;
    }
    [HttpPost]
    [Authorize]

    public async Task<ApiResponse> Add(AddScheduleDTO addDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _scheduleService.AddAsync(addDTO, cancellationToken);
        return serviceResult;
    }
    [HttpPost]
    [Authorize]

    public async Task<ApiResponse> AddItem(AddScheduleItemDto addDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _scheduleItemService.AddScheduleItemsAsync(addDTO, cancellationToken);
        return serviceResult;
    }
    [HttpPut]
    [Authorize]

    public async Task<ApiResponse> UpdateItem(UpdateScheduleItemDto addDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _scheduleItemService.UpdateScheduleItemsAsync(addDTO, cancellationToken);
        return serviceResult;
    }
    [HttpPut]
    [Authorize]


    public async Task<ApiResponse> Update(UpdateScheduleDTO updateDTO, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var serviceResult = await _scheduleService.UpdateAsync(updateDTO, cancellationToken);
        return serviceResult;
    }
    [HttpDelete]
    [Authorize]

    public async Task<ApiResponse> Remove(DeleteScheduleDTO dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return await _scheduleService.DeleteAsync(dto, cancellationToken);
    }
    [HttpDelete]
    [Authorize]

    public async Task<ApiResponse> RemoveItem(DeleteScheduleItemDto dto, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        return await _scheduleItemService.DeleteItemAsync(dto, cancellationToken);
    }
    [HttpGet]
    [Authorize]

    public async Task<ApiResponse> GetAll(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());

        var getAllParams = new GetAllParams(search, currentPage, pageSize);
        return await _scheduleService.GetAllAsync(getAllParams, cancellationToken);

    }
    [HttpGet]
    [Authorize]

    public async Task<ApiResponse> GetSchedules(string? search = default, int? currentPage = default, int? pageSize = default, CancellationToken cancellationToken = new())
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());

        var getAllParams = new GetAllParams(search, currentPage, pageSize);
        return await _scheduleService.GetAllScheduleAsync(getAllParams, cancellationToken);

    }


    //[HttpGet]
    //[Authorize]
    //[Route("{Id}")]

    //public async Task<ApiResponse> Item([AsParameters] long Id, CancellationToken cancellationToken = new())
    //{
    //    if (!ModelState.IsValid)
    //        throw new ApiException(ModelState.AllErrors());

    //    var dto = new GetScheduleItemByIdDTO(Id);
    //    return await _scheduleItemService.GetItemByIdAsync(dto, cancellationToken);
    //}
}
