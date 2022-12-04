namespace App_CleanArchitecture.Controllers;

using Application.Interfaces;
using AutoWrapper.Wrappers;
using Domain.Dtos.ManualControlDtos;

using Microsoft.AspNetCore.Mvc;

public class ManucalControlController : QController
{
    private readonly IManualControlService _service;
    public ManucalControlController(IManualControlService service)
    {
        _service = service;
    }
    [HttpGet]
    [Route("{Id}")]
    public async Task<ApiResponse> GetDoor(long Id, CancellationToken cancellationToken = new())
    {
        return await _service.GetDoorDetals(Id, cancellationToken);
    }
    [HttpPost]
    public async Task<ApiResponse> ManualControl(AddManualControlDto manualControlDto, CancellationToken cancellationToken = new())
    {
        return await _service.AddManualControl(manualControlDto, cancellationToken);
    }
}
