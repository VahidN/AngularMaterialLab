using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaterialAspNetCoreBackend.DataLayer.Migrations
{
    public partial class V2018_07_10_1445 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2018, 7, 11, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2018, 7, 20, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Title", "UserId" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 7, 13, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 1 });

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Title", "UserId" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 7, 25, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 1 });

            migrationBuilder.InsertData(
                table: "UserNotes",
                columns: new[] { "Id", "Date", "Title", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTimeOffset(new DateTime(2018, 7, 12, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 2 },
                    { 6, new DateTimeOffset(new DateTime(2018, 7, 13, 10, 15, 23, 282, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1993, 7, 10, 10, 15, 23, 275, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1983, 7, 10, 10, 15, 23, 276, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1973, 7, 10, 10, 15, 23, 276, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2018, 7, 8, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2018, 7, 17, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Title", "UserId" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 7, 9, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Make something ...", 2 });

            migrationBuilder.UpdateData(
                table: "UserNotes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Title", "UserId" },
                values: new object[] { new DateTimeOffset(new DateTime(2018, 7, 10, 15, 43, 10, 746, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Do something ...", 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1993, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1983, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTimeOffset(new DateTime(1973, 7, 7, 15, 43, 10, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
