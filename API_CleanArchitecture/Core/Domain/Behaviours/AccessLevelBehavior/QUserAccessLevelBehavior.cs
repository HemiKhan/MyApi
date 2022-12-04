namespace Domain.Models.AccessLevelModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Events.AccessLevelEvents;
using Domain.Events.QUserEvents;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record QUserAccessLevel
{
    public static QUserAccessLevel Create(long QUserId, long AccessLevelId) => new QUserAccessLevel( QUserId,  AccessLevelId);

    public void Update(Update_QUserAccessLevels_DTO dto)
    {
        var OldValue = new Update_QUserAccessLevels_EventParameters();
        var NewValue = new Update_QUserAccessLevels_EventParameters();
        bool hasChanges = false;
        if (!QUserId.Equals(dto.QUserId))
        {
            OldValue.QuserId = QUserId;
            NewValue.QuserId = (long)dto.QUserId!;
            hasChanges = true;
        }

        if (!AccessLevelId.Equals(dto.AccessLevelId))
        {
            OldValue.AccessLevelId = AccessLevelId;
            NewValue.AccessLevelId = (long)dto.AccessLevelId!;
            hasChanges = true;
        }

        if (hasChanges)
        {
            var e = new QUserAccessLevel_Updated(dto.Id, OldValue, NewValue);
            RegisterEvent(e);
        }
    }

    public Deleted<QUserAccessLevel> Delete()
    {
        var e = new QUserAccessLevel_Deleted(this);
        RegisterEvent(e);
        return new Deleted<QUserAccessLevel>(this, e);
    }
}
