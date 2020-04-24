using Microsoft.EntityFrameworkCore.Migrations;

namespace JungleBook.Migrations
{
	public partial class AddLatLongAndPlaceId : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "PlaceId",
				table: "Destinations",
				nullable: true);

			migrationBuilder.AddColumn<double>(
				name: "Latitude",
				table: "Addresses",
				nullable: true);

			migrationBuilder.AddColumn<double>(
				name: "Longitude",
				table: "Addresses",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlaceId",
				table: "Destinations");

			migrationBuilder.DropColumn(
				name: "Latitude",
				table: "Addresses");

			migrationBuilder.DropColumn(
				name: "Longitude",
				table: "Addresses");
		}
	}
}
