using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace redsquirrelcore.Migrations
{
    public partial class locationowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerUserId",
                table: "Location",
                type: "int8",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_OwnerUserId",
                table: "Location",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Users_OwnerUserId",
                table: "Location",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Users_OwnerUserId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_OwnerUserId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Location");
        }
    }
}
