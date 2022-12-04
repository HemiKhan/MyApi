using Application.Handlers;
using Application.Interfaces.Services.QUserServices;
using Domain.Dtos.Door;
using Domain.Dtos.QUserDtos;
using AutoWrapper.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

namespace App_CleanArchitecture.Controllers
{
    public class QUserController : QController
    {
        private readonly IQUserServices _qUserRepo;

        public QUserController(IQUserServices qUserServices)
        {
            _qUserRepo = qUserServices;
        }


        [Authorize]
        [HttpPost]
        public async Task<ApiResponse> Add(ADD_QUser_DTO dto, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }
            var serviceResult = await _qUserRepo.AddAsync(dto, cancellationToken);
            return serviceResult;
        }

        [HttpGet]
        [Authorize]

        public async Task<ApiResponse> GetAll(string? search, int? currentPage, int? pageSize, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());
            GetAllParams param = new(search, currentPage, pageSize);
            var response = await _qUserRepo.GetAll(param, cancellationToken);
            return response;
        }

        [HttpGet]
        [Authorize]
        public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new CancellationToken())
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());
            var qUser = await _qUserRepo.Get(Id, cancellationToken);
            return qUser;
        }

        [HttpDelete]
        [Authorize]
        public async Task<ApiResponse> Delete(Delete_QUser_DTO dto, CancellationToken cancellationToken = new())
        {
            if(!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());
            var response = await _qUserRepo.DeleteAsync(dto, cancellationToken);
            return response!;
        }

        [HttpPut]
        [Authorize]
        public async Task<ApiResponse> Update(Update_QUser_DTO dto, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());
            var response = await _qUserRepo.UpdateAsync(dto, cancellationToken);
            return response;
        }
    }
}
