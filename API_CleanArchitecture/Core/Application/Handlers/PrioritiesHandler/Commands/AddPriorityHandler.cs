namespace Application.Handlers.PrioritiesHandler.Commands;

using Application.Common;
using Application.Exceptions;
using Application.ExtensionMethods.Mappings.PrioritiesMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Application.Specifications.Base;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AddPriorityHandler(IRepository Repository) : ICommandHandler<AddPriorityDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<AddPriorityDTO> request, CancellationToken cancellationToken)
    {
        var IsNameAlreadyExists = await Repository.FirstOrDefaultAsync(
            Specs.PrioritiesSpecs.CheckNameAlreadyExists(request.Dto.Name),cancellationToken,false,false);
        if (IsNameAlreadyExists.Status == Status.Exception!)
            return IsNameAlreadyExists.Exception!;
        if (IsNameAlreadyExists.Value is not null)
            return HandlerExceptions.PrioritiesHandlerException.PriorityNameAlreadyExists!;

        var IsPLevelAlreadyExists = await Repository.FirstOrDefaultAsync(
            Specs.PrioritiesSpecs.CheckPriorityLevelAlreadyExists(request.Dto.PriorityLevel),cancellationToken,false,false);
        if (IsPLevelAlreadyExists.Status == Status.Exception!)
            return IsPLevelAlreadyExists.Exception!;
        if (IsPLevelAlreadyExists.Value is not null)
            return HandlerExceptions.PrioritiesHandlerException.PriorityLevelAlreadyExists!;

        var priority = Priority.Create(request.Dto);
        var response = await Repository.AddAsync(priority);
        if (response.Status == Status.Exception!)
            return response.Exception!;
        return response.Value!.Id;
    }
}
