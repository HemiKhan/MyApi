namespace Infrastructure.Services.AccessConfigsServices;

using Application.Common;
using Application.Handlers;
using Application.Handlers.Queries.AccessConfigsQueryHandlers;
using Application.Interfaces;
using Application.Interfaces.Services.AccessConfig;
using Domain.Dtos.AccessConfigDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public record AccessConfigService(IQSender Sender) : IAccessConfigService
{
    public async Task<QResult<GetByConfigKey_AccessConfigsDTO>> GetByConfigKey(string ConfigKey)
    {
        var requset = new GetByConfigKey_AccessConfig_Request() { ConfigKey = ConfigKey };
        var response = await Sender.Send(new QueryRequest<GetByConfigKey_AccessConfig_Request, GetByConfigKey_AccessConfigsDTO>(requset));
        if (response.Status == Status.Exception!)
            return response.Exception!;
        return response!;
    }

    public async Task<QResult<IEnumerable<GetByParentIdAccessConfigsDTO>>> GetChildByParentConfigKey(string ParentConfigKey)
    {
        var getAllParames = new GetAllParams(ParentConfigKey, null, null);
        var response = await Sender.Send(new GetAllQueryRequest<GetByParentIdAccessConfigsDTO>(getAllParames));
        if (response.Status is Status.Exception)
            return response.Exception!;
        return response!;
    }

    public async Task<QResult<long?>> UpdateAsync(UpdateAccessConfigDTO dto, CancellationToken cancellationToken = default)
    {
        var response = await Sender.Send(new CommandRequest<UpdateAccessConfigDTO>(dto));
        if (response.Status is Status.Exception)
            return response.Exception!;
        return response;
    }

    public async Task<QResult<long[]>> UpdateAsync(List<UpdateAccessConfigDTO> dto, CancellationToken cancellationToken = default)
    {
        List<long> Ids = new List<long>();
        foreach (var item in dto)
        {
            var response = await UpdateAsync(item!);
            Ids.Add(Convert.ToInt64(response.Value));
        }
        return Ids.ToArray()!;
    }


 
    
}
