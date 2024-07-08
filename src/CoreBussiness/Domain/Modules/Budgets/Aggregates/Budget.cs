using Domain.Abstractions.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;

namespace Domain.Modules.Budgets.Aggregates;
public class Budget : AggregateRoot
{
    public readonly List<Category> _categories = new();

    public Guid OwnerId { get; private set; }
    public DateOnly ReferencePeriod { get; private set; }
    public decimal TotalValue { get; private set; }

    public Category Category { get; private set; }

    public IEnumerable<Category> Categories
        => _categories;

    public void Register(Guid ownerId, DateOnly referencePeriod, decimal totalValue)
    {
        OwnerId = ownerId;
        ReferencePeriod = referencePeriod;
        TotalValue = totalValue;
    }

    public void AddCategory(string name, decimal limit)
    {
        _categories.Add(new (name, limit));
    }

    public void UpdateTotalValue(decimal totalValue)
    {
        TotalValue = totalValue;
    }

    public void RegisterTransaction(string category, DateTime createAt, string description, decimal value)
    {
        _categories
            .Single(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase))
            .RegisterTransaction(createAt, description, value);
    }
}
