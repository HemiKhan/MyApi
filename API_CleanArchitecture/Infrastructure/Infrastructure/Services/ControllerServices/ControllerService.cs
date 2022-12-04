namespace Infrastructure.Services.ControllerServices;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Interfaces.Services.ControllerDateTimeSettingServices;
using Domain.Constants;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.TimeZoneSettingDtos;

using AutoWrapper.Wrappers;

using System.Text;
using System.Threading.Tasks;

public record ControllerService(IQSender Sender, IControllerDateTimeSettingService _dateTime) : IControllerService
{
    public async Task<ApiResponse> AddAsync(AddControllerCommand dto, CancellationToken cancellationToken = new())
    {
        var AddEntity = new AddControllerCommand
           (
            dto.Name,
            dto.UserName,
            GetEncryptedPassword(dto.Password),
            dto.MACAddress,
            dto.OAK,
            dto.IsOneDoor,
            dto.Model
           );
        var controllerIdResult = await Sender.Send(new CommandRequest<AddControllerCommand>(AddEntity), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        await _dateTime.AddControllerDateTimeSetting(controllerIdResult.Value!.Value, cancellationToken);
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> UpdateAsync(Update_ControllerDTO dto, CancellationToken cancellationToken = new())
    {
        var updateEntity = new Update_ControllerDTO
            (
             dto.Id,
             dto.Name,
             dto.UserName,
             GetEncryptedPassword(dto.Password),
             dto.MACAddress,
             dto.OAK,
             dto.IsOneDoor,
             dto.Model
            );
        var controllerIdResult = await Sender.Send(new CommandRequest<Update_ControllerDTO>(updateEntity), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(Delete_ControllerDTO dto, CancellationToken cancellationToken = new())
    {
        var controllerIdResult = await Sender.Send(new CommandRequest<Delete_ControllerDTO>(dto), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    async Task<ApiResponse> IControllerService.GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken)
    {
        var controllerIdResult = await Sender.Send(new GetAllQueryRequest<GetAll_Controller_DTO>(getAllParams), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;

    }

    async Task<ApiResponse> IControllerService.GetAsync(long id, CancellationToken cancellationToken)
    {
        var controllerIdResult = await Sender.Send(new QueryRequest<long, GetControllerByIdDTO>(id), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    async Task<ApiResponse> IControllerService.GetDoorByControllerIdAsync(long id, CancellationToken cancellationToken)
    {
        var controllerIdResult = await Sender.Send(new QueryRequest<long, GetDoorByControllerIdDTO>(id), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    private string GetEncryptedPassword(string Password)
    {
        try
        {
            byte[] encode = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(encode);
        }
        catch (Exception ex) { Console.Write(ex.Message); return default!; }
    }
}
