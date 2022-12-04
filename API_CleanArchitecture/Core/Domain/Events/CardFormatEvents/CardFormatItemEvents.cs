using Domain.Models.CardFormatsModels;
using Domain.Models.ScheduleModels;

namespace Domain.Events.CardFormatEvents;

public record CardForrmatItem_Added(string Name, string EncodingRange, string Encoding) : IDomainEvent;
public record CardForrmatItem_Updated(long Id, string Name, string EncodingRange, string Encoding) : IDomainEvent;

public record CardFormatItem_Deleted(CardFormatItems cardFormatItems) : IDeleteDomainEvent;
