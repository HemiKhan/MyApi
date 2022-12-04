using Application.Handlers;
using Domain.Dtos.PrioritiesDTOs;
using Domain.Dtos.QUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.QUserServices
{
    public interface IQUserServices
    {
        Task<ApiResponse> AddAsync(ADD_QUser_DTO addQUser, CancellationToken cancellationToken = new());
        Task<ApiResponse> UpdateAsync(Update_QUser_DTO updateQUser, CancellationToken cancellationToken = new());
        Task<ApiResponse> DeleteAsync(Delete_QUser_DTO deleteQUser, CancellationToken cancellationToken = new());
        Task<ApiResponse> DeleteQUserCardAsync(Delete_QUserCard_DTO deleteQUser, CancellationToken cancellationToken = new());
        Task<ApiResponse> GetAll(GetAllParams getAllParams, CancellationToken cancellationToken = new());
        Task<ApiResponse> Get(long Id, CancellationToken cancellationToken = new());
    }
}
