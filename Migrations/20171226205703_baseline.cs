using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace redsquirrelcore.Migrations
{
    public partial class baseline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExternalUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount = table.Column<double>(type: "float8", nullable: false),
                    FoodId = table.Column<long>(type: "int8", nullable: true),
                    LocationId = table.Column<long>(type: "int8", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodConversion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstUnitId = table.Column<long>(type: "int8", nullable: true),
                    FoodId = table.Column<long>(type: "int8", nullable: true),
                    Ratio = table.Column<double>(type: "float8", nullable: false),
                    SecondUnitId = table.Column<long>(type: "int8", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodConversion_Unit_FirstUnitId",
                        column: x => x.FirstUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConversion_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodConversion_Unit_SecondUnitId",
                        column: x => x.SecondUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitConversion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstUnitId = table.Column<long>(type: "int8", nullable: true),
                    Ratio = table.Column<double>(type: "float8", nullable: false),
                    SecondUnitId = table.Column<long>(type: "int8", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitConversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitConversion_Unit_FirstUnitId",
                        column: x => x.FirstUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitConversion_Unit_SecondUnitId",
                        column: x => x.SecondUnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodConversion_FirstUnitId",
                table: "FoodConversion",
                column: "FirstUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConversion_FoodId",
                table: "FoodConversion",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodConversion_SecondUnitId",
                table: "FoodConversion",
                column: "SecondUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_FoodId",
                table: "Inventory",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversion_FirstUnitId",
                table: "UnitConversion",
                column: "FirstUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversion_SecondUnitId",
                table: "UnitConversion",
                column: "SecondUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodConversion");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "UnitConversion");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
