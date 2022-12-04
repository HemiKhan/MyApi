namespace Application.Handlers;

using Application.Common;


public record CommandRequest<TRequest>(TRequest Dto) : IRequest<QResult<long?>>;

public record CommandRequest<TRequest, TResponse>(TRequest Dto) : IRequest<QResult<TResponse?>>;

public record GetAllQueryRequest(GetAllParams GetAllParams);
public record GetAllQueryRequest<TResponse>(GetAllParams GetAllParams) : GetAllQueryRequest(GetAllParams), IRequest<QResult<IEnumerable<TResponse>?>>;

public record QueryRequest<TRequest, TResponse>(TRequest Request) : IRequest<QResult<TResponse?>>;
public record QueryRequest<TResponse>() : IRequest<QResult<TResponse?>>;


public record GetAllParams(string? SearchValue = default, int? PageIndex = default, int? PageSize = default);

