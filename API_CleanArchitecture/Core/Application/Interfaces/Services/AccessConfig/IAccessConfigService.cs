namespace Application.Interfaces.Services.AccessConfig;

using Domain.Dtos.AccessConfigDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccessConfigService
{
    public Task<QResult<long?>> UpdateAsync(UpdateAccessConfigDTO dto, CancellationToken cancellationToken = new());
    public Task<QResult<long[]>> UpdateAsync(List<UpdateAccessConfigDTO> DTOList, CancellationToken cancellationToken = new());
    public Task<QResult<GetByConfigKey_AccessConfigsDTO>> GetByConfigKey(string ConfigKey);
    public Task<QResult<IEnumerable<GetByParentIdAccessConfigsDTO>>> GetChildByParentConfigKey(string ConfigKey);
}
