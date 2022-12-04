namespace Application.Interfaces;

using Application.Handlers;

public interface IQSender
{
    IMediator Mediator { get; }

    Task<QResult<long?>> Send<TRequest>(CommandRequest<TRequest> request, CancellationToken cancellationToken = default);
    Task<QResult<TResponse?>> Send<TRequest, TResponse>(CommandRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default);

    Task<QResult<IEnumerable<TResponse>?>> Send<TResponse>(GetAllQueryRequest<TResponse> request, CancellationToken cancellationToken = default);
    Task<QResult<TResponse?>> Send<TRequest, TResponse>(QueryRequest<TRequest, TResponse> request, CancellationToken cancellationToken = default);
    Task<QResult<TResponse?>> Send<TResponse>(QueryRequest<TResponse> request, CancellationToken cancellationToken = default);

}
