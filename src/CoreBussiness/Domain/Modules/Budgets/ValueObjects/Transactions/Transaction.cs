namespace Domain.Modules.Budgets.ValueObjects.Transactions;
public record Transaction(DateTime CreateAt, string Description, decimal Value)
{
}
