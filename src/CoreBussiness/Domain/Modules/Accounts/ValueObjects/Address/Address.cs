namespace Domain.Modules.Accounts.ValueObjects.Address;
public record Address(string Street, string City, string State, string ZipCode, string Country, int? Number, string? Complement )
{
}
