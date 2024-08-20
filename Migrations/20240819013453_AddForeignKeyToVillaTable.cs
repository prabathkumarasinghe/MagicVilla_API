using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "villaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 11, 4, 53, 320, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 11, 4, 53, 320, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 11, 4, 53, 320, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 11, 4, 53, 320, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 11, 4, 53, 320, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.CreateIndex(
                name: "IX_villaNumbers_VillaID",
                table: "villaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_villaNumbers_villas_VillaID",
                table: "villaNumbers",
                column: "VillaID",
                principalTable: "villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villaNumbers_villas_VillaID",
                table: "villaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_villaNumbers_VillaID",
                table: "villaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "villaNumbers");

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 18, 15, 29, 8, 480, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 18, 15, 29, 8, 480, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 18, 15, 29, 8, 480, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 18, 15, 29, 8, 480, DateTimeKind.Local).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 18, 15, 29, 8, 480, DateTimeKind.Local).AddTicks(7412));
        }
    }
}
