namespace Application.Handlers.Commands.AccessLevelCommands;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using System.Threading;
using System.Threading.Tasks;

public record DeleteAccessLevelHandler(IRepository Repository) : ICommandHandler<Delete_AccessLevel_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Delete_AccessLevel_DTO> request, CancellationToken cancellationToken)
    {
        var GetEntityForDeletion = await Repository.FirstOrDefaultAsync
            (Specs.Common.GetById<AccessLevel, long>(request.Dto.Id),
            cancellationToken,
            false,
            false);
        if (GetEntityForDeletion.Status is Status.Exception)
            return GetEntityForDeletion.Exception!;
        if (GetEntityForDeletion.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist;

        var response = await Repository.DeleteAsync(GetEntityForDeletion.Value.Delete());
        return response.Status is Status.Exception ? response.Exception!  : response.Value!.Id;
    }
}
