using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rakas_BookStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class syncToLaptopDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Real Past events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Real Pasr events");
        }
    }
}
