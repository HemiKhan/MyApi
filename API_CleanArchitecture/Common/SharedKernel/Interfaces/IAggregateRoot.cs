namespace SharedKernel.Interfaces;

// Apply this marker interface only to aggregate root entities
// Repositories will only work with aggregate roots, not their children
public interface IAggregateRoot : IEntity
{
    public string AggregateId => GetType().Name;
    public List<IDomainEvent> DomainEvents { get; }
    public IEnumerable<IDomainEvent> GetDomainEvents() => DomainEvents.AsReadOnly();

    public void ClearDomainEvents() => DomainEvents.Clear();
}


public interface IAggregateRoot<TId> : IEntity<TId>, IAggregateRoot
{

}
