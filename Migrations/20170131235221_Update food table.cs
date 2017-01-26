using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace redsquirrel.Migrations
{
    public partial class Updatefoodtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodConversion_Foods_FoodId",
                table: "FoodConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Foods_FoodId",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodConversion_Food_FoodId",
                table: "FoodConversion",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Food_FoodId",
                table: "Inventory",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodConversion_Food_FoodId",
                table: "FoodConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Food_FoodId",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodConversion_Foods_FoodId",
                table: "FoodConversion",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Foods_FoodId",
                table: "Inventory",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
