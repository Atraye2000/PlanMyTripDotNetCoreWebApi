using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_appApi.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingForm",
                columns: table => new
                {
                    bookingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phno = table.Column<int>(type: "int", nullable: false),
                    adults = table.Column<int>(type: "int", nullable: false),
                    children = table.Column<int>(type: "int", nullable: false),
                    checkInDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingForm", x => x.bookingid);
                    table.ForeignKey(
                        name: "FK_bookingForm_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingForm_id",
                table: "bookingForm",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingForm");
        }
    }
}
