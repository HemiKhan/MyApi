namespace Domain.Models.CardFormatsModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.ControllerDTOs;
using Domain.Dtos.Door;
using Domain.Events.ControllerEvents;
using Domain.Events.ScheduleEvents;
using Domain.Models.ScheduleModels;

public partial record CardFormat
{

    public static CardFormat Create(AddCardFormatDto command) => new CardFormat(
                       command.Name,
                       command.Description!,
                       command.BitLength,
                       command.IsEnable
                      );
    public void AddCardFormat(AddCardFormatDto c)
    {
        var e = new CardForrmat_Added(c.Name, c.Description!, c.BitLength, false);
        RegisterEvent(e);
    }
    public void UpdateCardFormat(UpdateCardFormatDto c)
    {
        var e = new CardForrmat_Updated(c.Id, c.Name, c.Description!, c.BitLength, c.IsEnable);
        RegisterEvent(e);
    }
    public Deleted<CardFormat> Delete()
    {
        var e = new CardFormat_Deleted(this);
        RegisterEvent(e);
        return new Deleted<CardFormat>(this, e);
    }

}
