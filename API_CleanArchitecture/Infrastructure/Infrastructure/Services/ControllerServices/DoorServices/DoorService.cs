namespace Infrastructure.Services.DoorServices;

using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.DoorServices;
using Domain.Dtos.Door;

using AutoWrapper.Wrappers;

public record DoorService(IQSender Sender) : IDoorService
{
    public async Task<ApiResponse> AddAsync(Door_Add_DTO addDoorDTO, CancellationToken cancellationToken = default)
    {
        var scheduledResult = await Sender.Send(new CommandRequest<Door_Add_DTO>(addDoorDTO), cancellationToken);
        if (scheduledResult.Status is Status.Exception)
            throw scheduledResult.Exception!;
        return scheduledResult.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeleteDoorDTO deleteRequest, CancellationToken cancellationToken = default)
    {
        var scheduledResult = await Sender.Send(new CommandRequest<DeleteDoorDTO>(deleteRequest), cancellationToken);
        if (scheduledResult.Status is Status.Exception)
            throw scheduledResult.Exception!;
        return scheduledResult.Result!;
    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = default)
    {
        var controllerIdResult = await Sender.Send(new GetAllQueryRequest<GetAllDoorsDTO>(getAllParams), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        var controllerIdResult = await Sender.Send(new QueryRequest<long, Door_GetById_DTO>(id), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(Door_GetById_DTO updateDoorDTO, CancellationToken cancellationToken = default)
    {
        var scheduledResult = await Sender.Send(new CommandRequest<Door_GetById_DTO>(updateDoorDTO), cancellationToken);
        if (scheduledResult.Status is Status.Exception)
            throw scheduledResult.Exception!;
        return scheduledResult.Result!;
    }
}
