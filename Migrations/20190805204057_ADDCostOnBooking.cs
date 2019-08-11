using Microsoft.EntityFrameworkCore.Migrations;

namespace Ger_Garage.Migrations
{
    public partial class ADDCostOnBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Bookings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Bookings");
        }
    }
}
