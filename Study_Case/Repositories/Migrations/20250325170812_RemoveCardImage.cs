using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCardImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 209, DateTimeKind.Local).AddTicks(5572), new DateTime(2025, 3, 25, 20, 8, 10, 210, DateTimeKind.Local).AddTicks(3781) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 210, DateTimeKind.Local).AddTicks(4647), new DateTime(2025, 3, 25, 20, 8, 10, 210, DateTimeKind.Local).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(207), new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(506), new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(4151), new DateTime(2025, 3, 25, 20, 8, 10, 211, DateTimeKind.Local).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(3202), new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(3209) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7313), new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7634), new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7636) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7638), new DateTime(2025, 3, 25, 20, 8, 10, 221, DateTimeKind.Local).AddTicks(7638) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(1300), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2164), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2166) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2169), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2172), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2172) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 834, DateTimeKind.Local).AddTicks(9731), new DateTime(2025, 3, 24, 22, 51, 6, 835, DateTimeKind.Local).AddTicks(7951) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 835, DateTimeKind.Local).AddTicks(8883), new DateTime(2025, 3, 24, 22, 51, 6, 835, DateTimeKind.Local).AddTicks(8885) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(4741), new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(4744) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(5044), new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(5045) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(8760), new DateTime(2025, 3, 24, 22, 51, 6, 836, DateTimeKind.Local).AddTicks(8763) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(3138), new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(3142) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(6946), new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(6949) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(7268), new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(7272), new DateTime(2025, 3, 24, 22, 51, 6, 847, DateTimeKind.Local).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(853), new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1682), new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1684) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1687), new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1687) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1689), new DateTime(2025, 3, 24, 22, 51, 6, 848, DateTimeKind.Local).AddTicks(1689) });
        }
    }
}
