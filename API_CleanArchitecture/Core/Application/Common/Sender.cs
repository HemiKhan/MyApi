namespace Application.Common;

using System.Collections.Generic;
using System.Threading;

using Application.Handlers;

public record QSender(IMediator Mediator) : Application.Interfaces.IQSender
{
    public Task<QResult<long?>> Send<TRequest>(CommandRequest<TRequest> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    public Task<QResult<TResponse?>> Send<TRequest, TResponse>(CommandRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    public Task<QResult<TResponse?>> Send<TRequest, TResponse>(QueryRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    public Task<QResult<IEnumerable<TResponse>?>> Send<TResponse>(GetAllQueryRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }

    public Task<QResult<TResponse?>> Send<TResponse>(QueryRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return Mediator.Send(request, cancellationToken);
    }
}
