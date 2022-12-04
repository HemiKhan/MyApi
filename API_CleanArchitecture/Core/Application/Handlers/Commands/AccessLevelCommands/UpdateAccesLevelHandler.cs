namespace Application.Handlers.Commands.AccessLevelCommands;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.AccessLevelSpecifications;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using System.Threading;
using System.Threading.Tasks;

public record UpdateAccesLevelHandler(IRepository Repository) : ICommandHandler<Update_AccessLevel_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Update_AccessLevel_DTO> request, CancellationToken cancellationToken)
    {
        var DBEntity = await Repository
            .FirstOrDefaultAsync(
            Specs.Common.GetByIdWithInclude<AccessLevel, AccessLevelDoor>(request.Dto.Id,_=> _.AccessLevelDoors),
            cancellationToken,false,false);
        if (DBEntity.Status == Status.Exception)
            return DBEntity.Exception!;
        if (DBEntity.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist;

        var CheckNameValidation = await Repository
            .FirstOrDefaultAsync(AccessLevelSpecification
            .NameValidationForUpdateSpecs(request.Dto.Id, request.Dto.Name),cancellationToken,false,false);
        if (CheckNameValidation.Status == Status.Exception)
            return CheckNameValidation.Exception!;
        if (CheckNameValidation.Value  is not null)
            return HandlerExceptions.CommonHandlerExceptions.NameAlreadyExist;



        var AccessLevel = DBEntity.Value;
        await Repository.EnableChangeTracker(AccessLevel);
        AccessLevel.Update(request.Dto);

        var qRepositoryUpdateResult = await Repository.SaveChangesAsync(cancellationToken);
        if (qRepositoryUpdateResult.Status is Status.Exception)
            return qRepositoryUpdateResult.Exception!;

        return DBEntity.Value.Id;
    }
}
