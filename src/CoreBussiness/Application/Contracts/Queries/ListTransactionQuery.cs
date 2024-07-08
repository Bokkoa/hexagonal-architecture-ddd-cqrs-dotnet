
using Application.Abstractions.Contracts;

namespace Application.Contracts.Queries;
public record ListTransactionQuery(Guid AccountId, DateTime? CreateAt): IQuery
{
}
