namespace Application.Handlers.Queries.ControllerQueriesHanlders;

using Application.Common;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Specifications.Base;
using Domain.Dtos.ControllerDTOs;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public record Controller_GetAll_Handler(IDapperRepository Repository, IQClaims QClaims) : IGetAllQueryHandler<GetAll_Controller_DTO>
{

    async Task<QResult<IEnumerable<GetAll_Controller_DTO>?>> IRequestHandler<GetAllQueryRequest<GetAll_Controller_DTO>, QResult<IEnumerable<GetAll_Controller_DTO>?>>.Handle(GetAllQueryRequest<GetAll_Controller_DTO> request, CancellationToken cancellationToken)
    {

        var getall_Scroll_Specs = new GenericDSpec<string>
        {
            CommandText = @"qn_GetAll_Controller",
            Parameters = new { SearchValue = request.GetAllParams.SearchValue, PageNumber = request.GetAllParams.PageIndex ?? 1, PageSize = request.GetAllParams.PageSize ?? 50, OrganizationId = QClaims.OrganizationId }
        };
        var dbJsonResult = await Repository.ExecuteScalarAsync(
            getall_Scroll_Specs,
            false,
            cancellationToken);
        if (dbJsonResult.Status is Status.Exception)
            return dbJsonResult.Exception!;
        if (dbJsonResult.Status is Status.NotFound)
            return QResults.OK<IEnumerable<GetAll_Controller_DTO>?>(Enumerable.Empty<GetAll_Controller_DTO>());

        var result = JsonConvert.DeserializeObject<IEnumerable<GetAll_Controller_DTO>?>(dbJsonResult.Value!);
        return QResults.From(result);
    }
}
