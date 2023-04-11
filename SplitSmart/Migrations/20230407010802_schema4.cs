using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SplitSmart.Migrations
{
    /// <inheritdoc />
    public partial class schema4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "PaymentModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "PaymentModels");
        }
    }
}
