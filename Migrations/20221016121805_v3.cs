using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_appApi.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightBookingbid",
                table: "flights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "flightsBooking",
                columns: table => new
                {
                    bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    fid = table.Column<int>(type: "int", nullable: false),
                    currentDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightsBooking", x => x.bid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_flights_FlightBookingbid",
                table: "flights",
                column: "FlightBookingbid");

            migrationBuilder.AddForeignKey(
                name: "FK_flights_flightsBooking_FlightBookingbid",
                table: "flights",
                column: "FlightBookingbid",
                principalTable: "flightsBooking",
                principalColumn: "bid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flights_flightsBooking_FlightBookingbid",
                table: "flights");

            migrationBuilder.DropTable(
                name: "flightsBooking");

            migrationBuilder.DropIndex(
                name: "IX_flights_FlightBookingbid",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "FlightBookingbid",
                table: "flights");
        }
    }
}
