using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCardImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCardImage",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 589, DateTimeKind.Local).AddTicks(9646), new DateTime(2025, 3, 25, 20, 9, 59, 590, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 590, DateTimeKind.Local).AddTicks(8768), new DateTime(2025, 3, 25, 20, 9, 59, 590, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(4265), new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(4269) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(4558), new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(8340), new DateTime(2025, 3, 25, 20, 9, 59, 591, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 601, DateTimeKind.Local).AddTicks(7910), new DateTime(2025, 3, 25, 20, 9, 59, 601, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2349), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2353) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2763), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2764) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2767), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(2768) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7019), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7847), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7853), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7856), new DateTime(2025, 3, 25, 20, 9, 59, 602, DateTimeKind.Local).AddTicks(7856) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductCardImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCardImage" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(1300), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(1303), "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/0003-mpuf3tu-a_large.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCardImage" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2164), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2166), "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcTNtyK9OXNPvPrrO8AO3JpPGtv9lOTvDRfKku6m3ZqtaO0KRwPUAYmJjgQYoRJLY5HfSoBx4dCkd9O57yAbVdNxGrxgUKmT" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCardImage" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2169), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2170), "https://m.media-amazon.com/images/I/61tOfogRfXL.__AC_SX300_SY300_QL70_ML2_.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate", "ProductCardImage" },
                values: new object[] { new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2172), new DateTime(2025, 3, 25, 20, 8, 10, 222, DateTimeKind.Local).AddTicks(2172), "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSXIJhS_a--H2uKCFDS5BEYT41Vhmf717hT06Z9ySrFl4R_7p6tWkfUwXvyb-zQJJz9JDlOgVE5lxZa0Hr0u3eN4_YOfJk9n6S1V9JAuKqJIFPhpaYTP42Vfw" });
        }
    }
}
