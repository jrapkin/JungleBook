using Microsoft.EntityFrameworkCore.Migrations;

namespace JungleBook.Migrations
{
	public partial class RemovedListMapFromTravelerAndTrip : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "ApplicationUserId",
				table: "Travelers",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Travelers_ApplicationUserId",
				table: "Travelers",
				column: "ApplicationUserId");

			migrationBuilder.AddForeignKey(
				name: "FK_Travelers_AspNetUsers_ApplicationUserId",
				table: "Travelers",
				column: "ApplicationUserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Travelers_AspNetUsers_ApplicationUserId",
				table: "Travelers");

			migrationBuilder.DropIndex(
				name: "IX_Travelers_ApplicationUserId",
				table: "Travelers");

			migrationBuilder.DropColumn(
				name: "ApplicationUserId",
				table: "Travelers");
		}
	}
}
