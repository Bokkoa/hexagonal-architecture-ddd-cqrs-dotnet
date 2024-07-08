using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Domain.Modules.Budgets.ValueObjects.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.SqlServer.Databases.Configurations.Budgets;
public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(nameof(Budget));

        builder.HasKey(budget => budget.Id);

        builder
            .Property(prop => prop.ReferencePeriod)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime)
                );

        // ! INFO: In Dotnet Core 8 this declaration is not need, relate by the same assembly engine

        //builder.OwnsMany(
        //  budget => budget.Categories,
        //  categoryNavigationBuilder =>
        //  {
        //      categoryNavigationBuilder.ToTable(nameof(Category));

        //      categoryNavigationBuilder.WithOwner().HasForeignKey(c => c.BudgetId);
        //      categoryNavigationBuilder.Property<int>("Id").IsRequired();
        //      categoryNavigationBuilder.HasKey("Id");

        //      //categoryNavigationBuilder
        //      //      .OwnsMany(
        //      //          account => account.Transactions,
        //      //          transactionNavigationBuilder =>
        //      //          {
        //      //              transactionNavigationBuilder.ToTable(nameof(Transaction));

        //      //              transactionNavigationBuilder.Property<int>("Id").IsRequired();
        //      //              transactionNavigationBuilder.HasKey("Id");
        //      //          }
        //      //      );
        //  }
        //);
    }
}
