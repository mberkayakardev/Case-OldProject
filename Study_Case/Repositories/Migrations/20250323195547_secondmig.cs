using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "CreatedUserName", "IsActive", "ModifiedDate", "ModifiedUserId", "ModifiedUserName", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 22, 55, 47, 116, DateTimeKind.Local).AddTicks(6226), null, "Seed Data", true, new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(4652), null, null, "En yetkili kullanıcı", "Sistem Admin" },
                    { 2, new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(5595), null, "Seed Data", true, new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(5597), null, null, "Sadece sipariş verebilir. ", "Müşteri" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "CreatedUserName", "EmailConfirmed", "FalseEntryCount", "IsActive", "IsBlocked", "ModifiedDate", "ModifiedUserId", "ModifiedUserName", "UserEmail", "UserFullName", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(5271), null, "Seed Data", true, 0, true, false, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(5274), null, "Seed Data", "berkayakar@gmail.com", "Berkay AKAR", "berkayakar", "A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3" },
                    { 2, new DateTime(2025, 3, 23, 22, 55, 47, 128, DateTimeKind.Local).AddTicks(7284), null, "Seed Data", true, 0, true, false, new DateTime(2025, 3, 23, 22, 55, 47, 128, DateTimeKind.Local).AddTicks(7288), null, "Seed Data", "alturadmin@gmail.com", "Altur Admin ", "alturadmin", "A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1068), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1071) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1401), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1404), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5014), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5770), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5774), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5774) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5776), new DateTime(2025, 3, 23, 22, 55, 47, 129, DateTimeKind.Local).AddTicks(5777) });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "Id", "CreatedDate", "CreatedUserId", "CreatedUserName", "IsActive", "ModifiedDate", "ModifiedUserId", "ModifiedUserName", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1434), null, "Seed Data", true, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1438), null, null, 2, 1 },
                    { 2, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1726), null, "Seed Data", true, new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1728), null, null, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 299, DateTimeKind.Local).AddTicks(3229), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(1344) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(2488), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(2492), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(2492) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9203), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9965), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9966) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9969), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9971), new DateTime(2025, 3, 23, 22, 49, 20, 300, DateTimeKind.Local).AddTicks(9971) });
        }
    }
}
