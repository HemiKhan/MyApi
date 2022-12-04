namespace Domain.Dtos.AccessLevelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record Add_QUserAccessLevels_DTO(long AccessLevelId);
public record Get_QUserAccessLevels_DTO(long Id,long?AccessLevelId,long? QUserId);
public record Update_QUserAccessLevels_DTO(long Id,long?AccessLevelId,long? QUserId);

public class Update_QUserAccessLevels_EventParameters
{
    public long QuserId { get; set; }
    public long AccessLevelId { get; set; }
}

public class UserAccessLevelsDTO {
    public long Id { get; set; }
    public long AccessLevelId { get; set; }
}
