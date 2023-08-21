using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAtm.Migrations
{
    public partial class AccountChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtmPin",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtmPin",
                table: "Accounts");
        }
    }
}
