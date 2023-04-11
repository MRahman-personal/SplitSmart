using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitSmart.Migrations
{
    /// <inheritdoc />
    public partial class schema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ExpenseModels");

            migrationBuilder.AlterColumn<string>(
                name: "Member1",
                table: "GroupModels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "GroupModels",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpenseGroupName",
                table: "ExpenseModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_GroupModels_GroupName",
                table: "GroupModels",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseModels_ExpenseGroupName",
                table: "ExpenseModels",
                column: "ExpenseGroupName");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels",
                column: "ExpenseGroupName",
                principalTable: "GroupModels",
                principalColumn: "GroupName",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseModels_GroupModels_ExpenseGroupName",
                table: "ExpenseModels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_GroupModels_GroupName",
                table: "GroupModels");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseModels_ExpenseGroupName",
                table: "ExpenseModels");

            migrationBuilder.DropColumn(
                name: "ExpenseGroupName",
                table: "ExpenseModels");

            migrationBuilder.AlterColumn<string>(
                name: "Member1",
                table: "GroupModels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "GroupModels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ExpenseModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
