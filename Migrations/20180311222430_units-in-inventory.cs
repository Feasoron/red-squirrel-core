using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace redsquirrelcore.Migrations
{
    public partial class unitsininventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UnitId",
                table: "Inventory",
                type: "int8",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UnitId",
                table: "Inventory",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Unit_UnitId",
                table: "Inventory",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Unit_UnitId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_UnitId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Inventory");
        }
    }
}
