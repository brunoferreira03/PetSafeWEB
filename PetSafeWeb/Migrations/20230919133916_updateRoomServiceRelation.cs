using Microsoft.EntityFrameworkCore.Migrations;

namespace PetSafeWeb.Migrations
{
    public partial class updateRoomServiceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceIds",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceIds",
                table: "Rooms");
        }
    }
}
