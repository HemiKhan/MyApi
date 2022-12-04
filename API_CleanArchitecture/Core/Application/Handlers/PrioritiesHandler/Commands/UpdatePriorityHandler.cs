namespace Application.Handlers.PrioritiesHandler.Commands;

using Application.Common;
using Application.Exceptions;
using Application.ExtensionMethods.Mappings.PrioritiesMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record UpdatePriorityHandler(IRepository Repository) : ICommandHandler<Update_PriorityDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<Update_PriorityDTO> request, CancellationToken cancellationToken)
    {
        var IsIdExists = await Repository.FirstOrDefaultAsync(Specs.PrioritiesSpecs.CheckPriorityExistOrNot(request.Dto.Id), cancellationToken, false, false);
        if (IsIdExists.Status is Status.Exception)
            return IsIdExists.Exception!;
        if (IsIdExists.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist!;

        var IsNameAlreadyExists = await Repository.FirstOrDefaultAsync(Specs.PrioritiesSpecs.CheckNameAlreadyExists(request.Dto.Name,request.Dto.Id),cancellationToken, false, false);
        if (IsNameAlreadyExists.Status is Status.Exception)
            return IsIdExists.Exception!;
        if (IsNameAlreadyExists.Value is not null)
            return HandlerExceptions.CommonHandlerExceptions.NameAlreadyExist!;

        var IsPriorityLevelAlreadyExists = await Repository.FirstOrDefaultAsync(Specs.PrioritiesSpecs.CheckPriorityLevelAlreadyExists(request.Dto.PriorityLevel, request.Dto.Id), cancellationToken, false, false);
        if (IsPriorityLevelAlreadyExists.Status is Status.Exception)
            return IsPriorityLevelAlreadyExists.Exception!;
        if (IsPriorityLevelAlreadyExists.Value is not null)
            return HandlerExceptions.PrioritiesHandlerException.PriorityLevelAlreadyExists!;
        //var Id = Convert.ToInt64(request.Dto.Id);
        var entity = await Repository.FirstOrDefaultAsync(Specs.Common.GetById<Priority,long?>(Convert.ToInt64(request.Dto.Id)),cancellationToken,false,false);
        if (entity.Status is Status.Exception)
            return entity.Exception!;
        var priority = entity.Value!;

        await Repository.EnableChangeTracker(priority!);

        priority.Update(request.Dto);

        var response = await Repository.SaveChangesAsync(cancellationToken!);
        if (response.Status is Status.Exception)
            return response.Exception!;
        return  priority.Id;
    }
}
