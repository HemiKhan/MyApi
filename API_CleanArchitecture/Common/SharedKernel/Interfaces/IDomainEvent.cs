namespace SharedKernel.Interfaces;

using MediatR;

public interface IDomainEvent : INotification
{
}

public interface IDeleteDomainEvent : IDomainEvent
{
}