namespace App_CleanArchitecture.Controllers;

using Application.Handlers;
using Application.Interfaces.Services.ReaderServices;
using Domain.Dtos.ReaderDTOs;

using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

public class ReaderController : QController
{
    private readonly IReaderService _readerService;
    public ReaderController(IReaderService readerService)
    {
        _readerService = readerService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ApiResponse> Add(AddReaderDTO dto, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var respone = await _readerService.AddAsync(dto, cancellationToken);
        return respone;
    }

    [HttpPut]
    [Authorize]
    public async Task<ApiResponse> Update(UpdateReaderDTO dto, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var respone = await _readerService.UpdateAsync(dto, cancellationToken);
        return respone;
    }

    [HttpDelete]
    [Authorize]
    public async Task<ApiResponse> Update(DeleteReaderDTO dto, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var respone = await _readerService.DeleteAsync(dto, cancellationToken);
        return respone;
    }

    [HttpGet]
    [Authorize]
    public async Task<ApiResponse> Get(int id, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        var respone = await _readerService.GetAsync(id, cancellationToken);
        return respone;
    }

    [HttpGet]
    [Authorize]
    public async Task<ApiResponse> GetAll(string? search, int currentPage, int pageSize, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid)
            throw new ApiException(ModelState.AllErrors());
        GetAllParams param = new(search, currentPage, pageSize);
        var respone = await _readerService.GetAllAsync(param, cancellationToken);
        return respone;
    }
}
