namespace SharedKernel.Interfaces;
public interface IEntity
{
}

public interface IEntity<TId> : IEntity
{
    public TId Id { get; }
}