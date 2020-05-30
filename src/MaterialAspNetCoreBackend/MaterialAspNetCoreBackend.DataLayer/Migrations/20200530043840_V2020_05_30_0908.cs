using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaterialAspNetCoreBackend.DataLayer.Migrations
{
    public partial class V2020_05_30_0908 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "BirthDate", "Name" },
                values: new object[] { 1, "user1", "This is my biography ....", new DateTimeOffset(new DateTime(1995, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(3160), new TimeSpan(0, 0, 0, 0, 0)), "User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "BirthDate", "Name" },
                values: new object[] { 2, "user2", "This is my biography ....", new DateTimeOffset(new DateTime(1985, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(6227), new TimeSpan(0, 0, 0, 0, 0)), "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "BirthDate", "Name" },
                values: new object[] { 3, "user3", "This is my biography ....", new DateTimeOffset(new DateTime(1975, 5, 30, 4, 38, 39, 467, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 0, 0, 0, 0)), "User 3" });

            migrationBuilder.InsertData(
                table: "UserNotes",
                columns: new[] { "Id", "Date", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2020, 5, 31, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 1 },
                    { 2, new DateTimeOffset(new DateTime(2020, 6, 9, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(6882), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 1 },
                    { 3, new DateTimeOffset(new DateTime(2020, 6, 2, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7065), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 1 },
                    { 4, new DateTimeOffset(new DateTime(2020, 6, 14, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7086), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 1 },
                    { 5, new DateTimeOffset(new DateTime(2020, 6, 1, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7102), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 2 },
                    { 6, new DateTimeOffset(new DateTime(2020, 6, 2, 4, 38, 39, 481, DateTimeKind.Unspecified).AddTicks(7118), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_UserId",
                table: "UserNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
