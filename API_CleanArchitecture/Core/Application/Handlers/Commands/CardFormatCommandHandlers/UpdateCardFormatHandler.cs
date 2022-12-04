namespace Application.Handlers.Commands.CardFormatCommandHandlers;

using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Dtos.CardFormatDtos;
using Domain.Models.CardFormatsModels;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Specifications;
using Microsoft.EntityFrameworkCore;
using Application.Specifications.Base;
using System.Globalization;

internal record UpdateCardFormatHandler(IRepository repository) : ICommandHandler<UpdateCardFormatDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<UpdateCardFormatDto>, QResult<long?>>.Handle(CommandRequest<UpdateCardFormatDto> request, CancellationToken cancellationToken)
    {
        var spec = new GenericQSpec<CardFormat>()
        {
            SpecificationFunc = _ => _.Where(request.Dto.Id).Include(_ => _.CardFormatItems)
        };
        var oldCardFormat = await repository.FirstOrDefaultAsync(
           spec, cancellationToken, true, false);

        if (oldCardFormat.Status is Status.Exception)
            return oldCardFormat.Exception!;
        //If parent not null
        if (oldCardFormat.Value != null)
        {
            if (oldCardFormat.Value!.Name != request.Dto.Name)
            {
                var anyNameExist = await repository.AnyAsync(Specs.Common.GetByColumn<CardFormat>("Name", request.Dto.Name), cancellationToken, false, true);
                if (anyNameExist.Status is Status.Exception)
                    return anyNameExist.Exception!;
            }
            var cardFormat = oldCardFormat.Value!;
            await repository.EnableChangeTracker(cardFormat);

            cardFormat.UpdateCardFormat(request.Dto);
            var qRepositoryAddResult = await repository.SaveChangesAsync(cancellationToken);
            if (qRepositoryAddResult.Status is Status.Exception)
                return qRepositoryAddResult.Exception!;


            // Delete children
            foreach (var existingChildForDelete in oldCardFormat.Value.CardFormatItems.ToList())
            {
                if (!request.Dto.CardFormatItems!.Any(c => c.Id == existingChildForDelete.Id))
                    await repository.DeleteAsync(existingChildForDelete.Delete(), cancellationToken);
            }
            // Update and Insert children
            foreach (var childModel in request.Dto.CardFormatItems!)
            {

                var existingChild = oldCardFormat.Value.CardFormatItems
                    .Where(_ => _.Id == childModel.Id)
                    .SingleOrDefault();

                if (existingChild != null)
                {
                    var cardFormatItem = existingChild;
                    await repository.EnableChangeTracker(cardFormatItem);


                    var itemMapper = new UpdateFormatItems(childModel.Id, childModel.FieldMapName, childModel.EncodingRange, childModel.Encoding);
                    cardFormatItem.UpdateFormatItem(itemMapper);
                    var qUpdateResultItem = await repository.SaveChangesAsync(cancellationToken);
                    if (qUpdateResultItem.Status is Status.Exception)
                        return qUpdateResultItem.Exception!;
                }
                else
                {
                    // Insert child
                    var mapper = new FormatItems
                    {
                        FieldMapName = childModel.FieldMapName,
                        EncodingRange = childModel.EncodingRange,
                        Encoding = childModel.Encoding,
                    };
                    var cardFormatItem = CardFormatItems.Create(mapper, oldCardFormat.Value.Id);
                    Serilog.Log.Verbose(repository.DbContext.ChangeTracker.DebugView.LongView);
                    await repository.AddAsync(cardFormatItem);
                }
            }
        }
        return await Task.FromResult(oldCardFormat.Value!.Id);
    }
}
