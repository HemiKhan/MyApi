namespace Domain.Models.PrioritiesModels;

using Domain.Events.PriorityEvents;

public partial record Priority : AggregateRoot<long>, IMustHaveOrganization
{
    Priority()
    {
    }

    Priority(string name, string colorCode, int priorityLevel)
    {
        var e = new Priority_Added
            (
              new Dtos.PrioritiesDTOs.AddPriorityDTO
              (
                  name,
                  priorityLevel,
                  colorCode
              )
            );
        ApplyAndRegisterEvent(e);
    }
    public string? Name { get; private set; }
    public string? ColorCode { get; private set; }
    public int? PriorityLevel { get; private set; }
    public long OrganizationId { get; set; }
}
