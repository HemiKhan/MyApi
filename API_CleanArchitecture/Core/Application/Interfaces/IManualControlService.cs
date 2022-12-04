namespace Application.Interfaces;

using Domain.Dtos.ManualControlDtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IManualControlService
{
    Task<ApiResponse> GetDoorDetals(long Id, CancellationToken cancellationToken);
    Task<ApiResponse> AddManualControl(AddManualControlDto Dto, CancellationToken cancellationToken);
}
