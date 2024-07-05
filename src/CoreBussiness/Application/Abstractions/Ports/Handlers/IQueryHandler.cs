using Application.Abstractions.Contracts;

namespace Application.Abstractions.Ports.Handlers;
public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
}
