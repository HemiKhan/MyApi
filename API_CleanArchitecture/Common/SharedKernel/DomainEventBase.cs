namespace SharedKernel;

using MediatR;

public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;

    public Audit Events { get; set; }
}
