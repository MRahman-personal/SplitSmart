using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SplitSmart.Migrations
{
    /// <inheritdoc />
    public partial class schema3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseGroupName",
                table: "ExpenseModels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "PaymentModels",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpenseId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModels", x => x.PaymentId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels",
                column: "ExpenseGroupName",
                principalTable: "GroupModels",
                principalColumn: "GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels");

            migrationBuilder.DropTable(
                name: "PaymentModels");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseGroupName",
                table: "ExpenseModels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels",
                column: "ExpenseGroupName",
                principalTable: "GroupModels",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
