using Domain.Modules.Budgets.ValueObjects.Transactions;

namespace Domain.Modules.Budgets.ValueObjects.Categories;
public record Category(string Name, decimal Limit)
{
    List<Transaction> _transactions = new();

    public IEnumerable<Transaction> Transactions
        => _transactions.AsReadOnly();
    public void RegisterTransaction(DateTime createAt, string description, decimal value)
    {
        _transactions.Add(new(createAt, description, value));
    }
}
