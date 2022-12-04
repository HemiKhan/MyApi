namespace Application.Interfaces.Services.ReaderServices;
using System.Threading.Tasks;

using Application.Handlers;
using Domain.Dtos.ReaderDTOs;

public interface IReaderService
{
    Task<ApiResponse> AddAsync(AddReaderDTO addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> UpdateAsync(UpdateReaderDTO addUpdateControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> DeleteAsync(DeleteReaderDTO delete_ControllerDTO, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAllAsync(GetAllParams getAllParams, CancellationToken cancellationToken = new());
    Task<ApiResponse> GetAsync(long id, CancellationToken cancellationToken = new());
}
