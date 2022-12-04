namespace Domain.Models.TimeZoneModels;
using SharedKernel.Interfaces;

public record TimeZone(
    string DisplayString,
    string APIValue
    ) : AggregateRoot<long>, IMustHaveOrganization
{
    //DONT MESS WITH THIS LINE
    private TimeZone() : this("", "") { }


    public long OrganizationId { get; set; }

    protected override void When(IDomainEvent @event) => throw new NotImplementedException();
}
