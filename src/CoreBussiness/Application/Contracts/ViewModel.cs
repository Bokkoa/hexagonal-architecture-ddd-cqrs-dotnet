namespace Application.Contracts;
public static class ViewModel
{
    public record BalanceViewModel(Guid AccountId, decimal Income, decimal Expense);
    public record CategoryViewModel(Guid AccountId, string Name, decimal Limit);
    public record ExpenseByCategoryViewModel(Guid AccountId, DateTime CreateAt, string Description, decimal Value);
    public record TransactionViewModel(Guid AccountId, string Category, DateTime TransactionDate, string Description, decimal Value);
}
