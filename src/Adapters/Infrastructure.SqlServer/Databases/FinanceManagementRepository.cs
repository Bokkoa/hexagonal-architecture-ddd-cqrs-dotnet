using Application.Abstractions.Ports.Repositories;
using Domain.Abstractions.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.SqlServer.Databases;

public class FinanceManagementRepository : IFinanceManagementRepository
{
    private readonly DbContext _dbContext;

    public FinanceManagementRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) where TEntity : class
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<List<TEntity>> ListAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken) where TEntity : class
    {
        return await _dbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
    }
}
