
using Application.Abstractions.Contracts;

namespace Application.Contracts.Queries;
public record ListCategoryQuery(Guid AccountId): IQuery
{
}
