namespace Application.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

using SharedKernel.Interfaces;

using EventStore.Client;

public interface IEventStoreRepository
{

    public EventStoreClient Client { get; }
    public Task<TEntity> Find<TEntity>(Func<TEntity?, IDomainEvent, TEntity> When, string id, CancellationToken cancellationToken)
    {
        return default!;
    }

    public Task Append<TAggregate>(object id, IEnumerable<EventData> eventData, CancellationToken cancellationToken) where TAggregate : IAggregateRoot
    {

        //    var streamName = GetStreamName(aggregate, aggregate.Id);

        //    var result = await Client.AppendToStreamAsync(streamName, StreamState.Any, eventData, cancellationToken: cancellationToken);
        return Task.CompletedTask!;
    }

    public Task Append<TEntity>(object id, IDomainEvent domainEvent, long version, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private string GetStreamName<T>(T type, Guid aggregateId) => $"{type.GetType().Name}-{aggregateId}";
}
