using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Atheneum.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33", null, "Administrator", "ADMINISTRATOR" },
                    { "62d7b28e-bed6-4e62-a79b-b2488ed748c8", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "90460ea3-c382-4346-9007-0a5e498ff971", 0, "7dbf648d-93eb-422c-8a42-04c96a749760", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEAkhZ0oTRKV24C1rwgks+vyw+2CaMCgPi44dLJlmlO3BNDabhCPyoZLN32DGoodPlg==", null, false, "4b70fc47-1b0f-42ae-9f97-81349dbff66a", false, "user@bookstore.com" },
                    { "cb82080b-96e8-4839-8787-68b640eb095b", 0, "a1de2d75-aed2-4608-a425-d7e0cee12903", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEAM3HjWgbxKhHoT7dtfsD+LyFIceqf/18DZZ1WnBTuvrN7piYFzpFVUrDTw4zHDNHQ==", null, false, "ef608c92-fe3d-438a-b025-08b3a7714733", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "62d7b28e-bed6-4e62-a79b-b2488ed748c8", "90460ea3-c382-4346-9007-0a5e498ff971" },
                    { "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33", "cb82080b-96e8-4839-8787-68b640eb095b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62d7b28e-bed6-4e62-a79b-b2488ed748c8", "90460ea3-c382-4346-9007-0a5e498ff971" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33", "cb82080b-96e8-4839-8787-68b640eb095b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d77fdeb-1f38-4ea0-aaf7-f84352d68c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62d7b28e-bed6-4e62-a79b-b2488ed748c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90460ea3-c382-4346-9007-0a5e498ff971");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb82080b-96e8-4839-8787-68b640eb095b");
        }
    }
}
