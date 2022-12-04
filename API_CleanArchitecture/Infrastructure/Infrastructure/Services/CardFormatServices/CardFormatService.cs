namespace Infrastructure.Services.CardFormatServices;
using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Domain.Dtos;
using AutoWrapper.Wrappers;

using System.Threading.Tasks;
using Application.Interfaces.Services.CardFormatServices;
using Domain.Dtos.CardFormatDtos;
using System.Collections.Generic;
using System;
using AutoWrapper.Extensions;
using Domain.Exceptions;

public record CardFormatService(IQSender Sender) : ICardFormatService
{
    #region AddCardFormat
    public async Task<ApiResponse> AddAsync(AddCardFormatDto dto, CancellationToken cancellationToken = default)
    {
        FormatItemsValidator(dto);

        var qHResult = await Sender.Send(new CommandRequest<AddCardFormatDto>(dto), cancellationToken);
        if (qHResult.Status is Status.Exception)
            throw qHResult.Exception!;
        return qHResult.Result!;
    }

    private void FormatItemsValidator(AddCardFormatDto formatItems)
    {
        if (formatItems.CardFormatItems!.Any())
        {
            foreach (var item in formatItems.CardFormatItems!)
            {
                if (item.EncodingRange.Contains("-"))
                {
                    var splited = item.EncodingRange.Split("-");
                    var firstindex = splited.First().ToInt32();
                    var lastindex = splited.Last().ToInt32();
                    if (firstindex > formatItems.BitLength || lastindex > formatItems.BitLength)
                        throw new QException("Range Error");
                }
                else
                {
                    if (item.EncodingRange.ToInt32() > formatItems.BitLength)
                        throw new QException("Range Error");
                }
            }
        }
    }

    public async Task<ApiResponse> UpdateAsync(UpdateCardFormatDto dto, CancellationToken cancellationToken = default)
    {
        FormatItemsValidator(dto);
        var qHResult = await Sender.Send(new CommandRequest<UpdateCardFormatDto>(dto), cancellationToken);
        if (qHResult.Status is Status.Exception)
            throw qHResult.Exception!;
        return qHResult.Result!;
    }
    private void FormatItemsValidator(UpdateCardFormatDto formatItems)
    {
        if (formatItems.CardFormatItems!.Any())
        {
            foreach (var item in formatItems.CardFormatItems!)
            {
                if (item.EncodingRange.Contains("-"))
                {
                    var splited = item.EncodingRange.Split("-");
                    var firstindex = splited.First().ToInt32();
                    var lastindex = splited.Last().ToInt32();
                    if (firstindex > formatItems.BitLength || lastindex > formatItems.BitLength)
                        throw new QException("Range Error");
                }
                else
                {
                    if (item.EncodingRange.ToInt32() > formatItems.BitLength)
                        throw new QException("Range Error");
                }
            }
        }
    }
    #endregion
    #region GetCardFormats
    async Task<ApiResponse> ICardFormatService.GetAllScrollAsync(GetAllParams parameters, CancellationToken cancellationToken)
    {
        var controllerIdResult = await Sender.Send(new GetAllQueryRequest<GetAllCardFormatsDto>(parameters), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    public async Task<ApiResponse> DeleteAsync(DeleteCardFormatDto dto, CancellationToken cancellationToken = new())
    {
        var controllerIdResult = await Sender.Send(new CommandRequest<DeleteCardFormatDto>(dto), cancellationToken);
        if (controllerIdResult.Status is Status.Exception)
            throw controllerIdResult.Exception!;
        return controllerIdResult.Result!;
    }

    async Task<ApiResponse> ICardFormatService.FirstOrDefaultAsync(long Id, CancellationToken cancellationToken)
    {
        var senderResultFirsOrDefault = await Sender.Send(new QueryRequest<long, GetByIdCardFormatDto>(Id));
        if (senderResultFirsOrDefault.Status is Status.Exception)
            throw senderResultFirsOrDefault.Exception!;
        return senderResultFirsOrDefault.Result!;

    }


    #endregion

}
