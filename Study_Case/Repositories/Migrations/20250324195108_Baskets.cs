using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Baskets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketDetails_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_BasketId",
                table: "BasketDetails",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketDetails_ProductId",
                table: "BasketDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AppUserId",
                table: "Baskets",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDetails");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 116, DateTimeKind.Local).AddTicks(6226), new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(5595), new DateTime(2025, 3, 23, 22, 55, 47, 117, DateTimeKind.Local).AddTicks(5597) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1434), new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1438) });

            migrationBuilder.UpdateData(
                table: "AppUserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1726), new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(5271), new DateTime(2025, 3, 23, 22, 55, 47, 118, DateTimeKind.Local).AddTicks(5274) });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 22, 55, 47, 128, DateTimeKind.Local).AddTicks(7284), new DateTime(2025, 3, 23, 22, 55, 47, 128, DateTimeKind.Local).AddTicks(7288) });

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
        }
    }
}
