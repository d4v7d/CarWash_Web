using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.WEB.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "d7a3d927-4a73-4bc4-97b4-c595e7c2a593", "Admin", "ADMIN" },
                    { "2", "9f3265c6-f443-4330-b054-80e5e80af122", "Cliente", "CLIENTE" },
                    { "3", "86467756-7f32-4af9-bc28-19ffbd4b359b", "Empleado", "EMPLEADO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0867918-d39a-4c35-8baf-fca67a213dbc", 0, "da53db00-4f71-447d-a877-209112cb6579", "admin@admin.com", true, false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEPR06C7r/qZ/MbHYW1huo5xfzAbZuL8t5atGgHb3v0tZfHSDbBfFb2XTi913fSoOYQ==", null, false, "aec44513-82ad-4656-b1cd-987ac130376a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "b0867918-d39a-4c35-8baf-fca67a213dbc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "b0867918-d39a-4c35-8baf-fca67a213dbc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0867918-d39a-4c35-8baf-fca67a213dbc");
        }
    }
}
