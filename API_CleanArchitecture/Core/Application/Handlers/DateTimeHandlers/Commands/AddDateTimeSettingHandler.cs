namespace Application.Handlers.ControllerDateTimeSettingHandlers.Commands;

using System.Threading.Tasks;

using Application.ExtensionMethods.Mappings.ControllerDateTimeSettingMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.TimeZoneModels;


internal record AddDateTimeSettingHandler(IRepository Repository, IQClaims claims) : ICommandHandler<AddControllerDateTimeSettingDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<AddControllerDateTimeSettingDto>, QResult<long?>>.Handle(CommandRequest<AddControllerDateTimeSettingDto> request, CancellationToken cancellationToken)
    {

        var isExist = await Repository.AnyAsync(Specs.Common.GetByColumn<ControllerDateTime>("ControllerId", request.Dto.ControllerId), cancellationToken);
        if (isExist.Value is true)
            return new QException(HandlerMessages.ControllerHandlerMessages.ControllerNameAlreadyExist);
        var MapperEntity = ControllerDateTime.Create(request.Dto);

        var qRepositoryAddResult = await Repository.AddAsync(MapperEntity, cancellationToken);
        if (qRepositoryAddResult.Status == Status.Exception)
            throw qRepositoryAddResult.Exception!;
        return await Task.FromResult(qRepositoryAddResult.Value!.Id);
    }
}