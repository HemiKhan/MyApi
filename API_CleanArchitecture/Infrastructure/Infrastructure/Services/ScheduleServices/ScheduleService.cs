namespace Infrastructure.Services.ScheduleServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.ScheduleServices;
using Domain.Dtos;

using AutoWrapper.Wrappers;

using System.Threading.Tasks;


public record ScheduleService(IQSender Sender) : IScheduleService
{


    public async Task<ApiResponse> AddAsync(AddScheduleDTO addScheduleDTO, CancellationToken cancellationToken = new())
    {

        var scheduledResult = await Sender.Send(new CommandRequest<AddScheduleDTO>(addScheduleDTO), cancellationToken);
        if (scheduledResult.Status is Status.Exception)
            throw scheduledResult.Exception!;
        return scheduledResult.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(UpdateScheduleDTO dto, CancellationToken cancellationToken = new())
    {
        var controllerIdResult = await Sender.Send(new CommandRequest<UpdateScheduleDTO>(dto), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeleteScheduleDTO dto, CancellationToken cancellationToken = new())
    {
        var controllerIdResult = await Sender.Send(new CommandRequest<DeleteScheduleDTO>(dto), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken)
    {
        var controllerIdResult = await Sender.Send(new GetAllQueryRequest<Get_ScheduleDTO>(getAllParams), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;

    }
    public async Task<ApiResponse> GetAllScheduleAsync(GetAllParams getAllParams, CancellationToken cancellationToken)
    {
        var Result = await Sender.Send(new GetAllQueryRequest<GetScheduleDTO>(getAllParams), cancellationToken);
        if (Result.Status is Status.Exception)
            throw Result.Exception!;
        return Result.Result!;

    }

    //async Task<ApiResponse> IControllerService.GetAsync(long id, CancellationToken cancellationToken)
    //{
    //    var controllerIdResult = await Sender.Send(new QueryRequest<long, Get_ControllerInfoDTO>(id), cancellationToken);
    //    if (controllerIdResult.Status is Status.Exception)
    //        throw controllerIdResult.Exception!;
    //    return controllerIdResult.Result!;
    //}
}
