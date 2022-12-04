namespace Application.Interfaces;

using Application.Common;
using Application.Handlers;

internal interface ICommandHandler<TRequest> : IRequestHandler<CommandRequest<TRequest>, QResult<long?>>
{
}


internal interface ICommandHandler<TRequest, TResponse> : IRequestHandler<CommandRequest<TRequest, TResponse>, QResult<TResponse?>>
{
}


internal interface IGetAllQueryHandler<TResponse> : IRequestHandler<GetAllQueryRequest<TResponse>, QResult<IEnumerable<TResponse>?>>
{
}

internal interface IQueryHandler<TRequest, TResponse> : IRequestHandler<QueryRequest<TRequest, TResponse>, QResult<TResponse?>>
{
}
internal interface IQueryHandler<TResponse> : IRequestHandler<QueryRequest<TResponse>, QResult<TResponse?>>
{
}