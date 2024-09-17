using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_API.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "005eb2bb-ff18-4cbd-ae9b-5d337563ded7", "StoreOwner", "STOREOWNER" },
                    { "2", "cd1b9260-8d9c-45cb-8d28-59d9f90038ab", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "superadmin", 0, "1c6e4d5b-80d8-4371-a104-c8273e3e4797", "superadmin@example.com", true, false, null, "SUPERADMIN@EXAMPLE.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAENOQYPvZGhj05ZIvhAsENRbCKMasGLngAkNU4U8op4I02HX/15SsOoB5yqGq3jc/dA==", null, false, "a1fb6c47-f743-4eee-a8b9-edf4c69ed16b", false, "superadmin" },
                    { "user1", 0, "8a681fda-b69f-42ca-ba80-ff834805190c", "storeowner1@example.com", true, false, null, "STOREOWNER1@EXAMPLE.COM", "STOREOWNER1", "AQAAAAEAACcQAAAAEIfr1ol6NA6093exVO8xfu0do+HY1vAinhYKxEp80fPdPChlb/C6W9guRE5LOhnqQQ==", null, false, "6bc25bb0-04a5-4609-b061-e41d84b812d4", false, "storeowner1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "user1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "superadmin" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "user1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");
        }
    }
}
