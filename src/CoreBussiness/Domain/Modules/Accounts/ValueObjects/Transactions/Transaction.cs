namespace Domain.Modules.Accounts.ValueObjects.Transactions;
public record Transaction(DateTime CreateAt, string Description, decimal Value)
{
}
