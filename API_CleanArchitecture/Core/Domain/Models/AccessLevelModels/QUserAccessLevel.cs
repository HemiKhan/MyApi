namespace Domain.Models.AccessLevelModels;

using Domain.Events.AccessLevelEvents;
using Domain.Models.QUserModels;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record QUserAccessLevel : AggregateRoot<long> , IMustHaveOrganization
{
    private QUserAccessLevel() 
    {

    }

    QUserAccessLevel(long QUserId, long AccessLevelId) {
        var e = new QUserAccessLevel_Added(QUserId, AccessLevelId);
        RegisterEvent(e);
    }

    public AccessLevel AccessLevel { get; private set; } = default!;
    public long AccessLevelId { get; set; }

    public QUser QUser { get; set; } = default!;
    public long QUserId { get; set; }

    public long OrganizationId { get; set; }

   
}
