using Application.Abstractions.Contracts;


namespace Application.Contracts;
public static class Query
{
    public record GetBalanceQuery(string AccountId) : IQuery;
    public record ListCategoryQuery(Guid AccountId) : IQuery;
    public record ListExpenseByCategoryQuery(Guid AccountId, string Category) : IQuery;
    public record ListTransactionQuery(Guid AccountId, DateTime? CreateAt) : IQuery;
}
