namespace App_CleanArchitecture.Controllers;

using Application.Interfaces.Services.QUserServices;
using Domain.Dtos.QUserDtos;
using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class CardController : QController
{
    private readonly IQUserServices _services;

    public CardController(IQUserServices services)
    {
        _services = services;
    }
    [Authorize]
    [HttpDelete]
    public async Task<ApiResponse> Delete(Delete_QUserCard_DTO dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var response = await _services.DeleteQUserCardAsync(dto, cancellationToken);
        return response!;
    }
}
