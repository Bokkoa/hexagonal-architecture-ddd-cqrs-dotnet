namespace Application.Abstractions.Ports.Repositories;
public interface IFinanceManagementRepository
{
    Task SaveAsync<TEntity>(TEntity entity,  CancellationToken cancellationToken)
            where TEntity : class;
    Task<TEntity> GetAsync<TEntity>(Guid id, CancellationToken cancellationToken);

    IAsyncEnumerable<TEntity> GetAsync<TEntity>();
}
