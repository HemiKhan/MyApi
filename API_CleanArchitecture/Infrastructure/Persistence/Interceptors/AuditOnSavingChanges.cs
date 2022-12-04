namespace Persistence.Interceptors;
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using Application.Interfaces;
using Persistence.Constants;
using SharedKernel;
using SharedKernel.Interfaces;
using EventStore.Client;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

internal class AuditOnSavingChanges /*: ISaveChangesInterceptor*/
{
    //private readonly IDomainEventDispatcher _dispatcher;
    //private readonly EventStoreClient _storeClient;
    private readonly IQClaims _qClaims;

    public AuditOnSavingChanges(IQClaims qClaims)
    {
        //_dispatcher = domainEventDispatcher;
        //_storeClient = storeClient;
        _qClaims = qClaims;
    }

    //public void SaveChangesFailed(DbContextErrorEventData eventData)
    //{

    //}

    //public Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
    //{
    //    return Task.CompletedTask;
    //}

    //public int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    //{
    //    AddAuditOnSaveChanges(eventData);
    //    return result;
    //}

    //public async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    //{
    //    await AddAuditOnSaveChangesAsync(eventData, cancellationToken);
    //    return await Task.FromResult(result);
    //}

    //public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    //{
    //    AddOrganizationId(eventData.Context);
    //    AddToken(eventData.Context);
    //    AddTimestamp(eventData.Context);

    //    return result;
    //}

    //public async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    //{
    //    AddOrganizationId(eventData.Context);
    //    AddToken(eventData.Context);
    //    AddTimestamp(eventData.Context);

    //    return await ValueTask.FromResult(result);
    //}

    private void AddToken(DbContext? context)
    {
        foreach (var entry in context?.ChangeTracker.Entries<IMustHaveToken>()!)
        {
            var postFix = Constants.GetToken_PostFix(entry.Metadata.ClrType.Name);
            var guid = Guid.NewGuid();

            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(_ => _.Token).CurrentValue = guid.ToString("D") + "_" + postFix;
                    break;
                case EntityState.Modified:
                    entry.Property(_ => _.Token).IsModified = false;
                    break;
            }
        }
    }

    private void AddTimestamp(DbContext? context)
    {
        foreach (var entry in context?.ChangeTracker.Entries<Entity>()!)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(_ => _.CreatedDate).CurrentValue = DateTime.UtcNow;
                    entry.Property(_ => _.LastModifiedDate).IsModified = false;
                    break;
                case EntityState.Modified:
                    entry.Property(_ => _.LastModifiedDate).CurrentValue = DateTime.UtcNow;
                    entry.Property(_ => _.CreatedDate).IsModified = false;
                    break;
            }
        }
    }


    private void AddOrganizationId(DbContext? context)
    {
        foreach (var entry in context?.ChangeTracker.Entries<IMustHaveOrganization>()!)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Property(_ => _.OrganizationId).CurrentValue = _qClaims.OrganizationId;
                    break;
                case EntityState.Modified:
                    entry.Property(_ => _.OrganizationId).IsModified = false;
                    break;
            }
        }
    }

    //private async void AddAuditOnSaveChanges(DbContextEventData eventData)
    //{
    //    var events = AddAudit(eventData.Context).Result;
    //    Log.Verbose("Audit: {audits}", events);
    //    //if (events is not null)
    //    //{
    //    //    Log.Verbose("Saving Audit in Database");

    //    //    foreach (var ev in events)
    //    //    {
    //    //        var rr = _storeClient.AppendToStreamAsync(ev.StreamName, StreamState.Any, ev.EventData);
    //    //    }


    //    //    foreach (var ev in events)
    //    //    {
    //    //        var rr = _storeClient.AppendToStreamAsync(ev.StreamName, StreamState.Any, ev.EventData);
    //    //        var er = _storeClient.ReadStreamAsync(
    //    //    Direction.Forwards,
    //    //    ev.StreamName,
    //    //    StreamPosition.Start);

    //    //        await foreach (var @event in er)
    //    //        {
    //    //            Log.Verbose(Encoding.UTF8.GetString(@event.Event.Data.ToArray()));
    //    //        }
    //    //    }
    //    //}
    //}

    //private async Task AddAuditOnSaveChangesAsync(DbContextEventData eventData, CancellationToken cancellationToken)
    //{
    //    var events = await AddAudit(eventData.Context);
    //    if (events is not null)
    //    {
    //        Log.Verbose("Saving Audit in Database");
    //        //foreach (var ev in events)
    //        //{
    //        //    var rr = await _storeClient.AppendToStreamAsync(ev.StreamName, StreamState.Any, ev.EventData, cancellationToken: cancellationToken);
    //        //}

    //    //    var rr = await _storeClient.AppendToStreamAsync("Add_Controller", StreamState.Any, events, cancellationToken: cancellationToken);

    //        //foreach (var ev in events)
    //        //{
    //        //    var rr = await _storeClient.AppendToStreamAsync(ev.StreamName, StreamState.Any, ev.EventData, cancellationToken: cancellationToken);
    //        //    var e = _storeClient.ReadStreamAsync(
    //        //Direction.Forwards,
    //        //ev.StreamName,
    //        //StreamPosition.Start);

    //        //    await foreach (var @event in e)
    //        //    {
    //        //        Log.Verbose(Encoding.UTF8.GetString(@event.Event.Data.ToArray()));
    //        //    }
    //        //}

    //    }
    //}

    //record EventDataParameters(string StreamName, List<EventStore.Client.EventData> EventData);

    //private async Task<List<EventDataParameters>?> AddAudit(DbContext? context)
    //{
    //    if (context is null)
    //        return null;

    //    if (_dispatcher == null)
    //        return null;

    //    var jsonOption = new System.Text.Json.JsonSerializerOptions()
    //    {
    //        WriteIndented = true,
    //        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    //    };

    //    // dispatch events only if save was successful

    //    List<EventDataParameters> events = new();
    //    foreach (var entry in context.ChangeTracker.Entries<IAggregateRoot>())
    //    {
    //        var entity = entry.Entity;
    //        var streamName = entity.AggregateId;

    //        var domainEvents = entity.GetDomainEvents();

    //        var ed = domainEvents.Select(_ =>
    //           {


    //               var eventName = _.GetType().Name.Split("_");

    //               if (eventName is null || eventName.Length < 2)
    //                   eventName = new string[2] { "Unknown", "Unknown" };


    //               Audit? a = new Audit()
    //               {
    //                   OrganizationId = _qClaims.OrganizationId,
    //                   Operator = _qClaims.Operator,
    //                   IPAddress = _qClaims.IPAddress,
    //                   CreatedDate = DateTime.UtcNow,
    //                   Module = eventName![0],
    //                   Action = eventName![1],
    //                   Data = _

    //               };

    //               var jsonData = System.Text.Json.JsonSerializer.Serialize(a, jsonOption);

    //               var eventData = new EventStore.Client.EventData(
    //                   Uuid.NewUuid(),
    //               _.GetType().Name.Camelize(),
    //                  Encoding.UTF8.GetBytes(jsonData),
    //            Encoding.UTF8.GetBytes(_.GetType().FullName!.Camelize()));

    //               Log.Verbose("Audit: {jsonData}", jsonData);
    //               return eventData;


    //           }).ToList();
    //        events.Add(new(streamName, ed));
    //    }



    //    return await Task.FromResult(events);

    //}
}
