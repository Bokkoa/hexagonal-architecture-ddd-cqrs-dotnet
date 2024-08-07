﻿
using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Accounts.Aggregates;

namespace Application.Modules.Accounts.CommandHandlers;
public class CreateAccountHandler : CommandHandler<Command.CreateAccountCommand>
{
    private readonly IFinanceManagementRepository _repository;

    public CreateAccountHandler(IFinanceManagementRepository repository)
    {
        _repository = repository;
    }

    public override async Task Handle(Command.CreateAccountCommand command, CancellationToken cancellationToken)
    {
        Account account = new();
        account.Create(command.FirstName, command.LastName, command.Email);
        await _repository.InsertAsync(account, cancellationToken);
    }
}
