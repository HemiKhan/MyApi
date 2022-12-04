namespace Application.Handlers.PrioritiesHandler.Commands;

using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Exceptions;
using Application.ExtensionMethods.Mappings.PrioritiesMapping;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Models.PrioritiesModels;

public record DeletePriorityHandler(IRepository Repository) : ICommandHandler<DeletePriorityDTO>
{
    public async Task<QResult<long?>> Handle(CommandRequest<DeletePriorityDTO> request, CancellationToken cancellationToken)
    {
        var Entity = await Repository.FirstOrDefaultAsync(Specs.Common.GetById<Priority,long>(Convert.ToInt64(request.Dto.Id)), cancellationToken, false, false);
        if (Entity.Status is Status.Exception)
            return Entity.Exception!;
        if (Entity.Value is null)
            return HandlerExceptions.CommonHandlerExceptions.IdDoesNotExist;

        var response = await Repository.DeleteAsync(Entity.Value.Deleted());
        if (response.Status is Status.Exception)
            return response.Exception!;
        return response.Value!.Id;
    }
}
