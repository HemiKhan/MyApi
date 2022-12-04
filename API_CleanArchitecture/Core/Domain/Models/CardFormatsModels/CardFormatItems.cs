namespace Domain.Models.CardFormatsModels;

using Domain.Events.CardFormatEvents;

public partial record CardFormatItems : AggregateRoot<long>
{
    CardFormatItems() { }

    CardFormatItems(string cardFormatItemName, string encodingRange, string encoding)
    {
        var e = new CardForrmatItem_Added(cardFormatItemName, encodingRange, encoding);
        Apply(e);
        RegisterEvent(e);
    }

    public CardFormat CardFormat { get; private set; } = default!;
    public long CardFormatId { get; set; }
    public string Name { get; private set; } = default!;
    public string EncodingRange { get; private set; } = default!;
    public string Encoding { get; private set; } = default!;
}
