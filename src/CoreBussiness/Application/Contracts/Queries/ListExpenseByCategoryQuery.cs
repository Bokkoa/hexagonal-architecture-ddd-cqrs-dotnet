
using Application.Abstractions.Contracts;

namespace Application.Contracts.Queries;
public record ListExpenseByCategoryQuery(Guid AccountId, string Category) : IQuery
{
}
