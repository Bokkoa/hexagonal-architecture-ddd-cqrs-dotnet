namespace Application.Contracts.ViewModels;
public record TransactionViewModel(Guid AccountId, string Category, DateTime TransactionDate, string Description, decimal Value)
{
}
