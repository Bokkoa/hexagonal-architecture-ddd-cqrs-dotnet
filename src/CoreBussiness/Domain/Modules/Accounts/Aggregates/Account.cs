using Domain.Abstractions.Aggregates;
using Domain.Modules.Accounts.Entities.Profile;
using Domain.Modules.Accounts.ValueObjects.Address;
using Domain.Modules.Accounts.ValueObjects.Transactions;

namespace Domain.Modules.Accounts.Aggregates;
public class Account : AggregateRoot
{
    private readonly List<Transaction> _transactions = new();
    public Profile Profile { get; private set; }
    public Address Address { get; private set; }

    public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

    public void Create(string firstName, string lastName, string email) {
        Profile = new(firstName, lastName, email);
    }

    public void InformAddress(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        Address = new(street, city, state, zipCode, country, number, complement);
    }

    public void RegisterTransaction(DateTime createAt, string description, decimal value)
    {
        _transactions.Add(new(createAt, description, value));
    }
}
