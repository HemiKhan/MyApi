using Domain.Models.ScheduleModels;

namespace Domain.Models.CardFormatsModels;


public record CardForrmat_Added(string Name, string Description, int BitLength, bool IsEnable) : IDomainEvent;
public record CardForrmat_Updated(long Id, string Name, string Description, int BitLength, bool IsEnable) : IDomainEvent;
public record CardFormat_Deleted(CardFormat cardFormat) : IDeleteDomainEvent;
