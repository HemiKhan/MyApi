namespace Application.Handlers.Commands.QUserCommandHandlers;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.QUserDtos;
using Domain.Models.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Application.Constants.ModelFields;

public record DeleteQUserCardHandler(IRepository Repository) : ICommandHandler<Delete_QUserCard_DTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Delete_QUserCard_DTO> request, CancellationToken cancellationToken)
    {
       
        var DBEntity = await Repository.FirstOrDefaultAsync(Specs.Common.GetById<Domain.Models.CardModels.Card,long>(request.Dto.Id));
        if (DBEntity.Status is Status.Exception)
            return DBEntity.Exception!;
        if (DBEntity.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist!;

        var DeletResponse = await Repository.DeleteAsync(DBEntity.Value.Delete(), cancellationToken, true);
        if (DeletResponse.Status is Status.Exception)
            return DeletResponse.Exception!;
        return DeletResponse.Value!.Id;

    }
}
