namespace Domain.Models.PrioritiesModels;

using Domain.Events.PriorityEvents;

// Projection
public partial record Priority
{
    public void ApplyAndRegisterEvent(Priority_Added e)
    {
        Name = e.Value.Name;
        PriorityLevel = e.Value.PriorityLevel;
        ColorCode = e.Value.ColorCode;
        RegisterEvent(e);
    }

    public void ApplyAndRegisterEvent(Priority_NameUpdated e)
    {
        Name = e.New;
        RegisterEvent(e);
    }

    public void ApplyAndRegisterEvent(Priority_PrioeirtyLevelUpdated e)
    {
        PriorityLevel = e.New;
        RegisterEvent(e);
    }

    public void ApplyAndRegisterEvent(Priority_ColorCodeUpdated e)
    {
        ColorCode = e.New;
        RegisterEvent(e);
    }

}
