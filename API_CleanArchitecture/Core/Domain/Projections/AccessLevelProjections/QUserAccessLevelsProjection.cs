namespace Domain.Models.AccessLevelModels;

using Domain.Events.AccessLevelEvents;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record QUserAccessLevel
{

    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                QUserAccessLevel_Added e:
                Apply(e);
                break;
            case
                QUserAccessLevel_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    public void Apply(QUserAccessLevel_Added e) { 
    
        QUserId = e.QUserId; 
        AccessLevelId = e.AccessLevelId;
    }
    public void Apply(QUserAccessLevel_Updated e) {

        if (!QUserId.Equals(e.NewValue.QuserId) && e.NewValue.QuserId > 0)
        {
            QUserId = e.NewValue.QuserId;
        }

        if (!AccessLevelId.Equals(e.NewValue.AccessLevelId) && e.NewValue.AccessLevelId > 0)
        {
            AccessLevelId = e.NewValue.AccessLevelId;
        }
    }
}
