namespace Application.Handlers.Commands.AccessLevelCommands;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.AccessLevelSpecifications;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AddAccessLevelHandler(IRepository Repository) : ICommandHandler<Add_AccessLevel_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Add_AccessLevel_DTO> request, CancellationToken cancellationToken)
    {
        
        var IsNameAlreadyExists = await Repository.FirstOrDefaultAsync(AccessLevelSpecification
            .GetAccessLevelForNameValidationSpecs(request.Dto.Name), cancellationToken, false, false);
        if (IsNameAlreadyExists.Status == Status.Exception)
            return IsNameAlreadyExists.Exception!;
        if (IsNameAlreadyExists.Value is not null)
            return HandlerExceptions.CommonHandlerExceptions.NameAlreadyExist;

        var response = await Repository.AddAsync(AccessLevel.Create(request.Dto));
        return response.Status == Status.Exception ? response.Exception! : response.Value!.Id;

    }
}
