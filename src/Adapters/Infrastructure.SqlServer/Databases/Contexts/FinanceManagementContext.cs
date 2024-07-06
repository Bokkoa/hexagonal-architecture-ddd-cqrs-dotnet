﻿
using Application.Contracts.ViewModels;
using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profile;
using Domain.Modules.Accounts.ValueObjects.Address;
using Domain.Modules.Accounts.ValueObjects.Transactions;
using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Databases.Contexts;
public class FinanceManagementContext: DbContext
{
    #region Account
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    #endregion

    #region Budget
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Category> Categories { get; set; }
    #endregion

    #region Views
    public DbSet<BalanceViewModel> BalanceView { get; set; }
    public DbSet<CategoryViewModel> CategoryView { get; set; }
    public DbSet<TransactionViewModel> TransactionView { get; set; }
    #endregion
    public FinanceManagementContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<BalanceViewModel>().HasNoKey().ToView(nameof(BalanceViewModel));
        modelBuilder.Entity<CategoryViewModel>().HasNoKey().ToView(nameof(CategoryViewModel));
        modelBuilder.Entity<TransactionViewModel>().HasNoKey().ToView(nameof(TransactionViewModel));
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);
    }
}
