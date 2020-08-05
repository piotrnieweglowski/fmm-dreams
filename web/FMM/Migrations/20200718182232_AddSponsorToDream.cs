using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMM.Migrations
{
    public partial class AddSponsorToDream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SponsorId",
                table: "Dreams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_SponsorId",
                table: "Dreams",
                column: "SponsorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_Sponsors_SponsorId",
                table: "Dreams",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_Sponsors_SponsorId",
                table: "Dreams");

            migrationBuilder.DropIndex(
                name: "IX_Dreams_SponsorId",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "SponsorId",
                table: "Dreams");
        }
    }
}
