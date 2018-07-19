using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaterialAspNetCoreBackend.DataLayer.Migrations
{
    public partial class V2018_07_07_2012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                values: new object[] { 1, "user1", "This is my biography ....", new DateTimeOffset(new DateTime(1993, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "BirthDate", "Name" },
                values: new object[] { 2, "user2", "This is my biography ....", new DateTimeOffset(new DateTime(1983, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "BirthDate", "Name" },
                values: new object[] { 3, "user3", "This is my biography ....", new DateTimeOffset(new DateTime(1973, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "User 3" });

            migrationBuilder.InsertData(
                table: "UserNotes",
                columns: new[] { "Id", "Date", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2018, 7, 8, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 1 },
                    { 2, new DateTimeOffset(new DateTime(2018, 7, 17, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 1 },
                    { 3, new DateTimeOffset(new DateTime(2018, 7, 9, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 2 },
                    { 4, new DateTimeOffset(new DateTime(2018, 7, 10, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 3 }
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
