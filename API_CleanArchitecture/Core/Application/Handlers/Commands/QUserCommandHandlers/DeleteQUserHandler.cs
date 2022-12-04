namespace Application.Handlers.Commands.QUserCommandHandlers;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.QUserDtos;
using Domain.Models.QUserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record DeleteQUserHandler(IRepository Repository) : ICommandHandler<Delete_QUser_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Delete_QUser_DTO> request, CancellationToken cancellationToken)
    {
        var GetEntityByIdSpecs = new GenericQSpec<QUser, QUser>()
        {
            SpecificationFunc = _ => _.Where(x => x.Id == request.Dto.Id)
            .Include(x =>  x.Cards )
            .Include(x=> x.QUserAccessLevels)
            .Include(x=> x.QUserFiles)
        };

        var DBEntity = await Repository.FirstOrDefaultAsync(GetEntityByIdSpecs);
        if (DBEntity.Status is Status.Exception)
            return DBEntity.Exception!;
        if (DBEntity.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist!;

        var response = await Repository.DeleteAsync(DBEntity.Value.Delete(),cancellationToken, true);
        return response.Status is Status.Exception ? response.Exception! : response.Value!.Id;
   
    }
}
