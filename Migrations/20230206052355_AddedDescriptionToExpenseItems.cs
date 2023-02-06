﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expensetrackerservices.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionToExpenseItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExpenseItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExpenseItems");
        }
    }
}
