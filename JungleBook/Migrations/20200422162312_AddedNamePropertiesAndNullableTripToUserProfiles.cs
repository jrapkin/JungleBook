using Microsoft.EntityFrameworkCore.Migrations;

namespace JungleBook.Migrations
{
    public partial class AddedNamePropertiesAndNullableTripToUserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Destinations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Destinations");
        }
    }
}
