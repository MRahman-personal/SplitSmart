using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SplitSmart.Migrations
{
    /// <inheritdoc />
    public partial class schema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseModels",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    User1Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    User2Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    User3Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    User4Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    User5Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    User1Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    User2Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    User3Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    User4Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    User5Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    User1Payments = table.Column<string>(type: "text", nullable: true),
                    User2Payments = table.Column<string>(type: "text", nullable: true),
                    User3Payments = table.Column<string>(type: "text", nullable: true),
                    User4Payments = table.Column<string>(type: "text", nullable: true),
                    User5Payments = table.Column<string>(type: "text", nullable: true),
                    Receipt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseModels", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "GroupModels",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupName = table.Column<string>(type: "text", nullable: true),
                    Member1 = table.Column<string>(type: "text", nullable: true),
                    Member2 = table.Column<string>(type: "text", nullable: true),
                    Member3 = table.Column<string>(type: "text", nullable: true),
                    Member4 = table.Column<string>(type: "text", nullable: true),
                    Member5 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupModels", x => x.GroupId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseModels");

            migrationBuilder.DropTable(
                name: "GroupModels");
        }
    }
}
