using Application.Abstractions.Contracts;

namespace Application.Contracts.Queries;
public record GetBalanceQuery(string AccountId) : IQuery
{
}
