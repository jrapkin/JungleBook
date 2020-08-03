using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Persistence.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Addresses",
				columns: table => new
				{
					AddressId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Street = table.Column<string>(nullable: true),
					City = table.Column<string>(nullable: true),
					State = table.Column<string>(nullable: true),
					County = table.Column<string>(nullable: true),
					Region = table.Column<string>(nullable: true),
					Country = table.Column<string>(nullable: true),
					Latitude = table.Column<double>(nullable: true),
					Longitude = table.Column<double>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Addresses", x => x.AddressId);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					Name = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(nullable: false),
					UserName = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
					Email = table.Column<string>(maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(nullable: false),
					PasswordHash = table.Column<string>(nullable: true),
					SecurityStamp = table.Column<string>(nullable: true),
					ConcurrencyStamp = table.Column<string>(nullable: true),
					PhoneNumber = table.Column<string>(nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(nullable: false),
					TwoFactorEnabled = table.Column<bool>(nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
					LockoutEnabled = table.Column<bool>(nullable: false),
					AccessFailedCount = table.Column<int>(nullable: false),
					CustomTag = table.Column<string>(nullable: true),
					FirstName = table.Column<string>(nullable: true),
					LastName = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Trips",
				columns: table => new
				{
					TripId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true),
					EstimatedCost = table.Column<double>(nullable: false),
					StartDate = table.Column<DateTime>(nullable: false),
					EndDate = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Trips", x => x.TripId);
				});

			migrationBuilder.CreateTable(
				name: "Accommodations",
				columns: table => new
				{
					AccommodationId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true),
					AddressId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
					table.ForeignKey(
						name: "FK_Accommodations_Addresses_AddressId",
						column: x => x.AddressId,
						principalTable: "Addresses",
						principalColumn: "AddressId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Activities",
				columns: table => new
				{
					ActivityId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true),
					Description = table.Column<string>(nullable: true),
					AddressId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Activities", x => x.ActivityId);
					table.ForeignKey(
						name: "FK_Activities_Addresses_AddressId",
						column: x => x.AddressId,
						principalTable: "Addresses",
						principalColumn: "AddressId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<string>(nullable: false),
					ClaimType = table.Column<string>(nullable: true),
					ClaimValue = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(nullable: false),
					ClaimType = table.Column<string>(nullable: true),
					ClaimValue = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
					ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
					ProviderDisplayName = table.Column<string>(nullable: true),
					UserId = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<string>(nullable: false),
					RoleId = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<string>(nullable: false),
					LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
					Name = table.Column<string>(maxLength: 128, nullable: false),
					Value = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Travelers",
				columns: table => new
				{
					TravelerId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(nullable: true),
					LastName = table.Column<string>(nullable: true),
					UserName = table.Column<string>(nullable: true),
					Email = table.Column<string>(nullable: true),
					ApplicationUserId = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Travelers", x => x.TravelerId);
					table.ForeignKey(
						name: "FK_Travelers_AspNetUsers_ApplicationUserId",
						column: x => x.ApplicationUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "Destinations",
				columns: table => new
				{
					DestinationId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(nullable: true),
					ArrivalDate = table.Column<DateTime>(nullable: false),
					DepartureDate = table.Column<DateTime>(nullable: false),
					TripId = table.Column<int>(nullable: true),
					AddressId = table.Column<int>(nullable: false),
					PlaceId = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Destinations", x => x.DestinationId);
					table.ForeignKey(
						name: "FK_Destinations_Addresses_AddressId",
						column: x => x.AddressId,
						principalTable: "Addresses",
						principalColumn: "AddressId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Destinations_Trips_TripId",
						column: x => x.TripId,
						principalTable: "Trips",
						principalColumn: "TripId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "UserProfiles",
				columns: table => new
				{
					TravelerId = table.Column<int>(nullable: false),
					TripId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserProfiles", x => new { x.TravelerId, x.TripId });
					table.ForeignKey(
						name: "FK_UserProfiles_Travelers_TravelerId",
						column: x => x.TravelerId,
						principalTable: "Travelers",
						principalColumn: "TravelerId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserProfiles_Trips_TripId",
						column: x => x.TripId,
						principalTable: "Trips",
						principalColumn: "TripId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Days",
				columns: table => new
				{
					DayId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DayOfWeek = table.Column<DateTime>(nullable: false),
					AccommodationId = table.Column<int>(nullable: true),
					DestinationId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Days", x => x.DayId);
					table.ForeignKey(
						name: "FK_Days_Accommodations_AccommodationId",
						column: x => x.AccommodationId,
						principalTable: "Accommodations",
						principalColumn: "AccommodationId",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Days_Destinations_DestinationId",
						column: x => x.DestinationId,
						principalTable: "Destinations",
						principalColumn: "DestinationId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "DayActivities",
				columns: table => new
				{
					DayId = table.Column<int>(nullable: false),
					ActivityId = table.Column<int>(nullable: false),
					ActivityType = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_DayActivities", x => new { x.DayId, x.ActivityId });
					table.ForeignKey(
						name: "FK_DayActivities_Activities_ActivityId",
						column: x => x.ActivityId,
						principalTable: "Activities",
						principalColumn: "ActivityId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_DayActivities_Days_DayId",
						column: x => x.DayId,
						principalTable: "Days",
						principalColumn: "DayId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Addresses",
				columns: new[] { "AddressId", "City", "Country", "County", "Latitude", "Longitude", "Region", "State", "Street" },
				values: new object[,]
				{
					{ 1, "Denver", "United States", null, null, null, null, "Colorado", null },
					{ 2, "San Diego", "United States", null, null, null, null, "California", null },
					{ 3, "Seattle", "United States", null, null, null, null, "Washington", null },
					{ 4, "Tampa", "United States", null, null, null, null, "Florida", null },
					{ 5, "Galway", "Ireland", null, null, null, null, null, null },
					{ 6, "England", "United Kingdom", null, null, null, null, null, null }
				});

			migrationBuilder.InsertData(
				table: "Destinations",
				columns: new[] { "DestinationId", "AddressId", "ArrivalDate", "DepartureDate", "Name", "PlaceId", "TripId" },
				values: new object[,]
				{
					{ 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denver", null, null },
					{ 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Diego", null, null },
					{ 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", null, null },
					{ 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tampa", null, null },
					{ 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galway", null, null },
					{ 6, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", null, null }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Accommodations_AddressId",
				table: "Accommodations",
				column: "AddressId");

			migrationBuilder.CreateIndex(
				name: "IX_Activities_AddressId",
				table: "Activities",
				column: "AddressId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_DayActivities_ActivityId",
				table: "DayActivities",
				column: "ActivityId");

			migrationBuilder.CreateIndex(
				name: "IX_Days_AccommodationId",
				table: "Days",
				column: "AccommodationId");

			migrationBuilder.CreateIndex(
				name: "IX_Days_DestinationId",
				table: "Days",
				column: "DestinationId");

			migrationBuilder.CreateIndex(
				name: "IX_Destinations_AddressId",
				table: "Destinations",
				column: "AddressId");

			migrationBuilder.CreateIndex(
				name: "IX_Destinations_TripId",
				table: "Destinations",
				column: "TripId");

			migrationBuilder.CreateIndex(
				name: "IX_Travelers_ApplicationUserId",
				table: "Travelers",
				column: "ApplicationUserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserProfiles_TripId",
				table: "UserProfiles",
				column: "TripId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "DayActivities");

			migrationBuilder.DropTable(
				name: "UserProfiles");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "Activities");

			migrationBuilder.DropTable(
				name: "Days");

			migrationBuilder.DropTable(
				name: "Travelers");

			migrationBuilder.DropTable(
				name: "Accommodations");

			migrationBuilder.DropTable(
				name: "Destinations");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "Addresses");

			migrationBuilder.DropTable(
				name: "Trips");
		}
	}
}
