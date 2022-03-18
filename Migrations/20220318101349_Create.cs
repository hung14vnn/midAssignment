using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace midAssignment.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "BookBorrowingRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BookBorrowingRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "BookBorrowingRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookBorrowingRequests");
        }
    }
}
