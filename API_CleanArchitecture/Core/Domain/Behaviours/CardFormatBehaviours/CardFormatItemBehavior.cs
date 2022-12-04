namespace Domain.Models.CardFormatsModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.CardFormatDtos;
using Domain.Events.CardFormatEvents;
using Domain.Events.ScheduleEvents;
using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record CardFormatItems
{

    public static CardFormatItems Create(FormatItems command, long CardFormatId) => new CardFormatItems(
                     command.FieldMapName,
                     command.EncodingRange,
                     command.Encoding
                     )
    {
        CardFormatId = CardFormatId
    };

    public void UpdateFormatItem(UpdateFormatItems up)
    {
        var e = new CardForrmatItem_Updated(up.Id, up.FieldMapName, up.EncodingRange, up.Encoding);
        RegisterEvent(e);
    }
    public Deleted<CardFormatItems> Delete()
    {
        var e = new CardFormatItem_Deleted(this);
        RegisterEvent(e);
        return new Deleted<CardFormatItems>(this, e);
    }
}
