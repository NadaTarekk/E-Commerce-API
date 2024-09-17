using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_API.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8fc99923-7625-47b2-b375-c422fd6e73be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "dde95d69-c656-41e7-995e-e82883d5b379");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97330f28-d93d-4b35-96a0-91dffffe1cc2", "AQAAAAEAACcQAAAAELKSyZGC8cOU9WTUoOIjMoNXx2iUsFjnCX0oPBYCd5gUtplrQS1iBut/8Rn+A1nUrw==", "8106771f-7107-45c1-a5d6-ecc481ddec7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "916405bb-16b3-4577-b295-d1773bf8b4de", "AQAAAAEAACcQAAAAEJT5B5560pwz2kcrWlz6VetoWRvq0k5970irzydTgZbzj3Fe40l8uLpQyRcRpAJVPg==", "0b90c5c8-5a11-43eb-abb0-7ba327c03134" });

            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "DeliveryTime", "Description", "Name", "Price" },
                values: new object[] { 1, "5-7 Business Days", "Economical shipping option", "Standard Shipping", 5.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "7f7f5270-198e-42d1-a2dd-03dc783cb1b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5f1eb057-bf36-483d-991f-0541287dfdf1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "superadmin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d43b716a-1e41-42e4-8a75-4e78f88acd1c", "AQAAAAEAACcQAAAAEOUsj9eRoIZmmoRJy+z3Qi+SNTSSyrvEi/odtU0XpOvWWrmlWn+S925UrTL7LVCcjA==", "beb8caab-9706-4dce-b7a9-b9492ff92c8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2a0868c-e9f5-40b8-842d-f7d4fd25e1af", "AQAAAAEAACcQAAAAELkOT073/GTZNceti50bdCRvUKcD1dilDWKXyFs90TBAVHp47bzcNU7/8431spPsUg==", "195d089b-99f5-456a-bfa9-5b75a54436fa" });
        }
    }
}
