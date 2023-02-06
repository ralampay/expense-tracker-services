using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensetrackerservices.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToExpenseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ExpenseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_Categories_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseItems_CategoryId",
                table: "ExpenseItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ExpenseItems");
        }
    }
}
