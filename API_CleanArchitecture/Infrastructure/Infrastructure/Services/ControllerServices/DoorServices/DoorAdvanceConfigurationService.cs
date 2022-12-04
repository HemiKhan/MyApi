namespace Infrastructure.Services.DoorServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.DoorServices;
using Domain.Dtos.Door;
using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal record DoorAdvanceConfigurationService(IQSender Sender) : IDoorAdvanceConfigurationService
{
    public async Task<ApiResponse> AddAsync(AddDoorAdvanceConfgDTO addDoorAdvanceConfgDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<AddDoorAdvanceConfgDTO>(addDoorAdvanceConfgDTO),cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeleteDoorAdvanceConfgDTO deleteDoorAdvanceConfgDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<DeleteDoorAdvanceConfgDTO>(deleteDoorAdvanceConfgDTO), cancellationToken);
        if(response.Status == Status.Exception)
            throw response.Exception!;
        return response.Result!;

    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new QueryRequest<GetAllParams, GetAllDoorAdvanceConfgDTO>(getAllParams), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new QueryRequest<long, GetAllDoorAdvanceConfgDTO>(id), cancellationToken);
        if(response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(UpdateDoorAdvanceConfgDTO updateDoorAdvanceConfgDTO, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<UpdateDoorAdvanceConfgDTO>(updateDoorAdvanceConfgDTO), cancellationToken);
        if (response.Status is Status.Exception)
            throw response.Exception!;
        return response.Result!;
    }
}
