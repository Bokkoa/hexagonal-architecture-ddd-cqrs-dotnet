namespace Application.Contracts.ViewModels;
public record ExpenseByCategoryViewModel(Guid AccountId, DateTime CreateAt, string Description, decimal Value)
{
}
