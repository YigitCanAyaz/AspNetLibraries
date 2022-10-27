using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentValidation.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddPropBirthDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Customers");
        }
    }
}
