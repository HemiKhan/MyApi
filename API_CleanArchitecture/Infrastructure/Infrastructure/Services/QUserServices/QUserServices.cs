using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.QUserServices;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Dtos.QUserDtos;
using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.QUserServices
{
    public record QUserServices(IQSender Sender) : IQUserServices
    {
        public async Task<ApiResponse> AddAsync(ADD_QUser_DTO addQUser, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new CommandRequest<ADD_QUser_DTO>(addQUser), cancellationToken);
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }

        public async Task<ApiResponse> DeleteAsync(Delete_QUser_DTO deleteQUser, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new CommandRequest<Delete_QUser_DTO>(deleteQUser), cancellationToken);
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }

        public async Task<ApiResponse> DeleteQUserCardAsync(Delete_QUserCard_DTO deleteQUser, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new CommandRequest<Delete_QUserCard_DTO>(deleteQUser));
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }

        public async Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new QueryRequest<long, GetById_QUser_DTO>(Id), cancellationToken);
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }

        public async Task<ApiResponse> GetAll(GetAllParams getAllParams, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new GetAllQueryRequest<GetAll_QUser_DTO>(getAllParams));
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }

        public async Task<ApiResponse> UpdateAsync(Update_QUser_DTO updateQUser, CancellationToken cancellationToken = default)
        {
            var response = await Sender.Send(new CommandRequest<Update_QUser_DTO>(updateQUser), cancellationToken);
            if (response.Status is Status.Exception)
                throw response.Exception!;
            return response.Result!;
        }


    }
}
