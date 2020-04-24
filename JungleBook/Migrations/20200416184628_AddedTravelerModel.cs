using Microsoft.EntityFrameworkCore.Migrations;

namespace JungleBook.Migrations
{
	public partial class AddedTravelerModel : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_UserProfiles_AspNetUsers_ApplicationUserId",
				table: "UserProfiles");

			migrationBuilder.DropPrimaryKey(
				name: "PK_UserProfiles",
				table: "UserProfiles");

			migrationBuilder.DropColumn(
				name: "ApplicationUserId",
				table: "UserProfiles");

			migrationBuilder.AddColumn<int>(
				name: "TravelerId",
				table: "UserProfiles",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
				name: "PK_UserProfiles",
				table: "UserProfiles",
				columns: new[] { "TravelerId", "TripId" });

			migrationBuilder.CreateTable(
				name: "Travelers",
				columns: table => new
				{
					TravelerId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(nullable: true),
					LastName = table.Column<string>(nullable: true),
					UserName = table.Column<string>(nullable: true),
					Email = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Travelers", x => x.TravelerId);
				});

			migrationBuilder.AddForeignKey(
				name: "FK_UserProfiles_Travelers_TravelerId",
				table: "UserProfiles",
				column: "TravelerId",
				principalTable: "Travelers",
				principalColumn: "TravelerId",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_UserProfiles_Travelers_TravelerId",
				table: "UserProfiles");

			migrationBuilder.DropTable(
				name: "Travelers");

			migrationBuilder.DropPrimaryKey(
				name: "PK_UserProfiles",
				table: "UserProfiles");

			migrationBuilder.DropColumn(
				name: "TravelerId",
				table: "UserProfiles");

			migrationBuilder.AddColumn<string>(
				name: "ApplicationUserId",
				table: "UserProfiles",
				type: "nvarchar(450)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddPrimaryKey(
				name: "PK_UserProfiles",
				table: "UserProfiles",
				columns: new[] { "ApplicationUserId", "TripId" });

			migrationBuilder.AddForeignKey(
				name: "FK_UserProfiles_AspNetUsers_ApplicationUserId",
				table: "UserProfiles",
				column: "ApplicationUserId",
				principalTable: "AspNetUsers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
