namespace Domain.Models.CardFormatsModels;

using Domain.Events.CardFormatEvents;

using System.Xml.Linq;

public partial record CardFormatItems
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                CardForrmatItem_Added e:
                Apply(e);
                break;
            case
                CardForrmatItem_Updated e:
                Apply(e);
                break;
            case
                CardFormatItem_Deleted e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    public void Apply(CardForrmatItem_Added e)
    {
        Name = e.Name;
        EncodingRange = e.EncodingRange;
        Encoding = e.Encoding;
    }
    public void Apply(CardForrmatItem_Updated e)
    {
        Id = e.Id;
        Name = e.Name;
        EncodingRange = e.EncodingRange;
        Encoding = e.Encoding;
    }
    public void Apply(CardFormatItem_Deleted e)
    {
        Id = e.cardFormatItems.Id;
        CardFormatId = e.cardFormatItems.Id;
        Name = e.cardFormatItems.Name;
        EncodingRange = e.cardFormatItems.EncodingRange;
        Encoding = e.cardFormatItems.Encoding;
    }
}