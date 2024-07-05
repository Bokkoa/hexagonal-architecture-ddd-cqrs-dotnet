using Application.Abstractions.Contracts;

namespace Application.Abstractions.Handlers;

public abstract class QueryHandler <TQuery, TResponse> where TQuery : IQuery
{
    public abstract Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
