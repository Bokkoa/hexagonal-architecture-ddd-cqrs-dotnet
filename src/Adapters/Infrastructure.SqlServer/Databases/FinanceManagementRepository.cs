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

    public async Task UpdateAsync<TEntity, TProperty>(Expression<Func<TEntity, bool>> expression, TProperty property, CancellationToken cancellationToken)
         where TEntity : class
    {
        var entity = await _dbContext.Set<TEntity>().FirstAsync(expression, cancellationToken);
        _dbContext.Attach(entity);
        _dbContext.Entry(entity).Property(nameof(TProperty)).CurrentValue = property;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        where TEntity : class
    {
        var entity = await _dbContext.Set<TEntity>().FirstAsync(expression, cancellationToken);
        _dbContext.Set<TEntity>().Remove(entity);
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
