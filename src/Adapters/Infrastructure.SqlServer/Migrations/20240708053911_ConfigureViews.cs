using Application.Contracts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                CREATE VIEW {nameof(ViewModel.BalanceViewModel)} AS
                    SELECT
                        b.OwnerId AS AccountId
                        SUM(b.TotalValue) AS TotalSpent,
                        (SUM(b.TotalValue) - ISNULL(SUM(t.Value), 0)) AS Balance
                    FROM
                        Budget b
                    LEFT JOIN
                        [Category] c ON c.BudgetId = b.Id
                    JOIN
                        [Transaction] t ON c.Id = t.CategoryId
                    GROUP BY
                        b.OwnerId;

            ");

            migrationBuilder.Sql($@"
                  CREATE VIEW {nameof(ViewModel.CategoryViewModel)} AS
                        SELECT
                            c.BudgetId AS AccountId
                            c.Name AS CategoryName
                            c.Limit AS CategoryLimit
                        FROM
                            Category c;
            ");

            migrationBuilder.Sql($@"
                  CREATE VIEW {nameof(ViewModel.TransactionViewModel)} AS
                        SELECT
                            b.OwnerId AS AccountId
                            cat.Name AS Category
                            t.CreateAt,
                            t.Description
                            t.Value
                        FROM
                            [Transaction] t
                        JOIN
                            Category cat ON t.CategoryId = cat.Id
                        JOIN
                            Budget b ON cat.BudgetId = b.Id
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DROP VIEW IF EXISTS {nameof(ViewModel.BalanceViewModel)}");
            migrationBuilder.Sql($"DROP VIEW IF EXISTS {nameof(ViewModel.CategoryViewModel)}");
            migrationBuilder.Sql($"DROP VIEW IF EXISTS {nameof(ViewModel.TransactionViewModel)}");
        }
    }
}
