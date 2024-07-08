using Application.Abstractions.Contracts;

namespace Application.Contracts;
public static class Command
{
    public record CreateAccountCommand(string FirstName, string LastName, string Email) : Message, ICommand;
    public record AddCategoryCommand(Guid BudgetId, string Name, decimal Limit) : Message, ICommand;
    public record InformAddressCommand(string Street, string City, string State, string ZipCode, string Country, int? Number, string? Complement)
        : Message, ICommand;
    public record RegisterBudgetCommand(Guid AccountId, DateOnly ReferencePeriod, decimal TotalValue)
        : Message, ICommand;
    public record RegisterTransactionCommand(string Category, DateTime CreateAt, string Daescription, decimal Value)
        : Message, ICommand;
    public record UpdateTotalLimitCommand(decimal TotalValue) : Message, ICommand;
}
