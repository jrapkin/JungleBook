using Microsoft.EntityFrameworkCore.Migrations;

namespace JungleBook.Migrations
{
	public partial class UpdatedMappedProperties : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "AddressId",
				table: "Destinations",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "TripId",
				table: "Destinations",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "DestinationId",
				table: "Days",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Destinations_AddressId",
				table: "Destinations",
				column: "AddressId");

			migrationBuilder.CreateIndex(
				name: "IX_Destinations_TripId",
				table: "Destinations",
				column: "TripId");

			migrationBuilder.CreateIndex(
				name: "IX_Days_DestinationId",
				table: "Days",
				column: "DestinationId");

			migrationBuilder.AddForeignKey(
				name: "FK_Days_Destinations_DestinationId",
				table: "Days",
				column: "DestinationId",
				principalTable: "Destinations",
				principalColumn: "DestinationId",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Destinations_Addresses_AddressId",
				table: "Destinations",
				column: "AddressId",
				principalTable: "Addresses",
				principalColumn: "AddressId",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Destinations_Trips_TripId",
				table: "Destinations",
				column: "TripId",
				principalTable: "Trips",
				principalColumn: "TripId",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Days_Destinations_DestinationId",
				table: "Days");

			migrationBuilder.DropForeignKey(
				name: "FK_Destinations_Addresses_AddressId",
				table: "Destinations");

			migrationBuilder.DropForeignKey(
				name: "FK_Destinations_Trips_TripId",
				table: "Destinations");

			migrationBuilder.DropIndex(
				name: "IX_Destinations_AddressId",
				table: "Destinations");

			migrationBuilder.DropIndex(
				name: "IX_Destinations_TripId",
				table: "Destinations");

			migrationBuilder.DropIndex(
				name: "IX_Days_DestinationId",
				table: "Days");

			migrationBuilder.DropColumn(
				name: "AddressId",
				table: "Destinations");

			migrationBuilder.DropColumn(
				name: "TripId",
				table: "Destinations");

			migrationBuilder.DropColumn(
				name: "DestinationId",
				table: "Days");
		}
	}
}
