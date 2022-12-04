namespace Application.Handlers.Commands.CardFormatHandler;
using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications;
using Domain.Dtos.CardFormatDtos;
using Domain.Models.CardFormatsModels;

using MediatR;

internal record AddCardFormatHandler(IRepository Repository) : ICommandHandler<AddCardFormatDto>
{
    async Task<QResult<long?>> IRequestHandler<CommandRequest<AddCardFormatDto>, QResult<long?>>.Handle(CommandRequest<AddCardFormatDto> request, CancellationToken cancellationToken)
    {
        var isAlreadyExistWithSameName = await Repository.FirstOrDefaultAsync(
            Specs.Common.GetByColumn<CardFormat>(ModelFields.CommonFields.Name, request.Dto.Name),
          cancellationToken, false, true);

        if (isAlreadyExistWithSameName.Status is Status.Exception)
            return isAlreadyExistWithSameName.Exception!;

        var cardFormat = CardFormat.Create(request.Dto);
        var qRepositoryAddResult = await Repository.AddAsync(cardFormat);
        if (qRepositoryAddResult.Status == Status.Exception)
            return qRepositoryAddResult.Exception!;
        if (request.Dto.CardFormatItems!.Any())
        {
            foreach (var item in request.Dto.CardFormatItems!)
            {
                var cardFormatItem = CardFormatItems.Create(item, qRepositoryAddResult.Value!.Id);
                await Repository.AddAsync(cardFormatItem, cancellationToken);
            }
        }
        return await Task.FromResult(qRepositoryAddResult.Value!.Id);
    }
}
