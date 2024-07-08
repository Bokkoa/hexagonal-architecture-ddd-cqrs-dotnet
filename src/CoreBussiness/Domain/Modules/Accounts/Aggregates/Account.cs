using Domain.Abstractions.Aggregates;
using Domain.Modules.Accounts.Entities.Profile;
using Domain.Modules.Accounts.ValueObjects.Address;

namespace Domain.Modules.Accounts.Aggregates;
public class Account : AggregateRoot
{
    public Profile Profile { get; private set; }
    public Address Address { get; private set; }

    public void Create(string firstName, string lastName, string email) {
        Id = Guid.NewGuid();
        Profile = new(firstName, lastName, email);
    }

    public void InformAddress(string street, string city, string state, string zipCode, string country, int? number, string? complement)
    {
        Address = new(street, city, state, zipCode, country, number, complement);
    }


}
