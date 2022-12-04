using Domain.Events.CardFormatEvents;

namespace Domain.Models.CardFormatsModels;
public partial record CardFormat
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                CardForrmat_Added e:
                Apply(e);
                break;
            case
                CardForrmat_Updated e:
                Apply(e);
                break;
            case
                CardFormat_Deleted e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    public void Apply(CardForrmat_Added e)
    {
        Name = e.Name;
        Description = e.Description;
        BitLength = e.BitLength;
        IsEnable = e.IsEnable;
    }
    public void Apply(CardForrmat_Updated e)
    {
        Id = e.Id;
        Name = e.Name;
        Description = e.Description;
        BitLength = e.BitLength;
        IsEnable = e.IsEnable;
    }
    public void Apply(CardFormat_Deleted e)
    {
        Id = e.cardFormat.Id;
        Name = e.cardFormat.Name;
        Description = e.cardFormat.Description;
        BitLength = e.cardFormat.BitLength;
        IsEnable = e.cardFormat.IsEnable;
    }
}
