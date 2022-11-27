using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_appApi.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookingForm_users_Userid",
                table: "bookingForm");

            migrationBuilder.DropIndex(
                name: "IX_bookingForm_Userid",
                table: "bookingForm");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "bookingForm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "bookingForm",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookingForm_Userid",
                table: "bookingForm",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_bookingForm_users_Userid",
                table: "bookingForm",
                column: "Userid",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
