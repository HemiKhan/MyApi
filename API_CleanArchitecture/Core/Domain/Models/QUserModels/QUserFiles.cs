namespace Domain.Models.QUserModels;

using Domain.Events.PriorityEvents;
using Domain.Events.QUserEvents;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record QUserFile : AggregateRoot<long>, IMustHaveOrganization
{
    private QUserFile()
    {
    }

    QUserFile(long QUserId,string ImageName,string ImageData) {
        var e = new QUserFile_Added(QUserId, ImageName, ImageData);
        RegisterEvent(e);

    }
    public QUser QUser { get;private set; } = default!;
    public long QUserId { get;private set; }
    public string? ImageName { get; private set; }
    public byte[]? ImageData { get; private set; }
    public long OrganizationId { get; private set; }

}
