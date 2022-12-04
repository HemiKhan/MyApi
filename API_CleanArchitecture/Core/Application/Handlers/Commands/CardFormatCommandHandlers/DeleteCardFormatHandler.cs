namespace Application.Handlers.Commands.CardFormatCommandHandlers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Models.CardFormatsModels;
using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record DeleteCardFormatHandler(IRepository Repository, IQClaims QClaims, IRepository itemRepo) : ICommandHandler<DeleteCardFormatDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<DeleteCardFormatDto>, QResult<long?>>.Handle(CommandRequest<DeleteCardFormatDto> request, CancellationToken cancellationToken)
    {
        // CardFormat GET BY ID SPECIFICATION
        var getCardFormatByIdSpec = new GenericQSpec<CardFormat>()
        {
            SpecificationFunc = _ => _.Where(request.Dto.Id)
        };

        // GET ALL ITEMS BY CardFormatId SPECIFICATIONS
        var getItemsSpec = new GenericQSpec<CardFormatItems>()
        {
            SpecificationFunc = _ => _.Where(_ => _.CardFormatId == request.Dto.Id)
        };

        //CHECK ID WHITHIN OGR IS EXIST IN DATABASE
        var cardFormatResult = await Repository.FirstOrDefaultAsync(getCardFormatByIdSpec, cancellationToken);
        if (cardFormatResult.Status is Status.Exception)
            return QResults.Exception<long?>(cardFormatResult.Exception!);
        if (cardFormatResult.Value == null)
            return QResults.NotFound<long?>(HandlerMessages.CardFormatHandlerMessages.NotFound);
        // FETCHING LIST OF ITEMS AGAINS Card FORMAT ID
        var itemsResult = await itemRepo.GetAllAsync(getItemsSpec, cancellationToken);
        if (itemsResult.Value!.Count() > 0)
        {
            // DELETING ALL Card Format ITEMS
            foreach (var item in itemsResult.Value!)
            {
                await itemRepo.DeleteAsync(item.Delete(), cancellationToken);
            }
        }
        // DELETING Card Format
        var deleteResult = Repository.DeleteAsync(
          cardFormatResult.Value!.Delete(), cancellationToken).Result;
        if (deleteResult.Status is Status.Exception)
            return QResults.Exception<long?>(deleteResult.Exception!);

        return await Task.FromResult(deleteResult.Value!.Id);
    }
}
