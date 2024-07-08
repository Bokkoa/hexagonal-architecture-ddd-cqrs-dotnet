using Application.Abstractions.Contracts;

namespace Application.Contracts.Commands;
public record InformAddressCommand(string Street, string City, string State, string ZipCode, string Country, int? Number, string? Complement) 
    : Message, ICommand
{
}
