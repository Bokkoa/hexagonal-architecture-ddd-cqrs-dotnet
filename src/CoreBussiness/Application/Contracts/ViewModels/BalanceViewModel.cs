namespace Application.Contracts.ViewModels;
public record BalanceViewModel(Guid AccountId, decimal Income, decimal Expense)
{
}
