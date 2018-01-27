using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace redsquirrelcore.Migrations
{
    public partial class objectowners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "UnitConversion",
                type: "int8",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "Unit",
                type: "int8",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "Inventory",
                type: "int8",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "FoodConversion",
                type: "int8",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "Food",
                type: "int8",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversion_OwnerUserId",
                table: "UnitConversion",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_OwnerUserId",
                table: "Unit",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_OwnerUserId",
                table: "Inventory",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConversion_OwnerUserId",
                table: "FoodConversion",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_OwnerUserId",
                table: "Food",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Users_OwnerUserId",
                table: "Food",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodConversion_Users_OwnerUserId",
                table: "FoodConversion",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Users_OwnerUserId",
                table: "Inventory",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Users_OwnerUserId",
                table: "Unit",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitConversion_Users_OwnerUserId",
                table: "UnitConversion",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Users_OwnerUserId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodConversion_Users_OwnerUserId",
                table: "FoodConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Users_OwnerUserId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Users_OwnerUserId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitConversion_Users_OwnerUserId",
                table: "UnitConversion");

            migrationBuilder.DropIndex(
                name: "IX_UnitConversion_OwnerUserId",
                table: "UnitConversion");

            migrationBuilder.DropIndex(
                name: "IX_Unit_OwnerUserId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_OwnerUserId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_FoodConversion_OwnerUserId",
                table: "FoodConversion");

            migrationBuilder.DropIndex(
                name: "IX_Food_OwnerUserId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "UnitConversion");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "FoodConversion");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Food");
        }
    }
}
