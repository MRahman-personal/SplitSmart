using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitSmart.Migrations
{
    /// <inheritdoc />
    public partial class schema5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "User1Payments",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "User2Payments",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "User3Payments",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "User4Payments",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "User5Payments",
                table: "ExpenseModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "ExpenseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User1Payments",
                table: "ExpenseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User2Payments",
                table: "ExpenseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User3Payments",
                table: "ExpenseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User4Payments",
                table: "ExpenseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User5Payments",
                table: "ExpenseModels",
                type: "text",
                nullable: true);
        }
    }
}
