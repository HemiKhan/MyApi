namespace Application.Handlers.ControllerDateTimeSettingHandlers.Commands;

using System.Threading.Tasks;

using Application.Common;
using Application.ExtensionMethods.Mappings.ControllerDateTimeSettingMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.TimeZoneModels;

internal record UpdateControllerDateTimeSettingsHandler(IRepository Repository) : ICommandHandler<UpdateControllerDateTimeSettingDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<UpdateControllerDateTimeSettingDto>, QResult<long?>>.Handle(CommandRequest<UpdateControllerDateTimeSettingDto> request, CancellationToken cancellationToken)
    {

        var existResult = await Repository.FirstOrDefaultAsync(Specs.Common.GetByColumn<ControllerDateTime>("ControllerId", request.Dto.ControllerId), cancellationToken, true, false);
        if (existResult.Status is Status.Exception)
            throw existResult.Exception!;

        var controllerDateTime = existResult.Value!;
        await Repository.EnableChangeTracker(controllerDateTime);

        controllerDateTime.UpdateControllerDateTimeSetting(request.Dto);
        var updateResult = await Repository.SaveChangesAsync(cancellationToken);
        if (updateResult.Status == Status.Exception)
            throw updateResult.Exception!;
        return await Task.FromResult(controllerDateTime!.ControllerId);
    }
}