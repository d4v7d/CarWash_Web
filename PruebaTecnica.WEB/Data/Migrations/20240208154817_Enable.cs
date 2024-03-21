using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.WEB.Data.Migrations
{
    public partial class Enable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "74d5c7fc-5374-4864-b11a-4346fac10c5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74d5c7fc-5374-4864-b11a-4346fac10c5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5ce2d53b-24b0-4fd7-9d10-31d2e7c1d4ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "83f5db6b-171b-4a5c-b58c-54a8cf5f43ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "00431e3a-69ab-4cf3-87e2-47e38606a509");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0fed4fa4-351b-4c23-bcd0-b7b09bec6329", 0, "78bc8667-8a22-4165-9105-422dfd372b01", "admin@admin.com", false, false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELAYx6BXmiMU38io0LIdTVzJOSLWX6fdhQrp01IVtLu7/Ds1PGCgCb/H+fk9FJ1jcg==", null, false, "d081ffba-b082-4304-af8f-9e8fb0e3b641", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "0fed4fa4-351b-4c23-bcd0-b7b09bec6329" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0fed4fa4-351b-4c23-bcd0-b7b09bec6329" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fed4fa4-351b-4c23-bcd0-b7b09bec6329");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a2aa22c7-1fa6-4d11-929d-5de23dea2e0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3e9f66be-aff2-41ec-a086-03daecf80143");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ed7a5360-a0ac-40fa-83b0-7b95856f5562");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74d5c7fc-5374-4864-b11a-4346fac10c5e", 0, "90a683e3-9ec8-443b-ac03-36ab3bc91362", "admin@admin.com", true, false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFDPdbMPfCuWJbOtQC+jKXbJ1yAo7gFKsjm9mTDti9UgE6qCltIXYYz1P8qDa24uHQ==", null, false, "3ccab05b-2d05-4fce-983b-35b1f25ad9d8", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "74d5c7fc-5374-4864-b11a-4346fac10c5e" });
        }
    }
}
