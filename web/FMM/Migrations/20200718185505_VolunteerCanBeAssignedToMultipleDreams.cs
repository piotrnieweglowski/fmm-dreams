using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMM.Migrations
{
    public partial class VolunteerCanBeAssignedToMultipleDreams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Dreams_DreamId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_DreamId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "DreamId",
                table: "Volunteers");

            migrationBuilder.CreateTable(
                name: "DreamVolunteer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DreamId = table.Column<Guid>(nullable: false),
                    VolunteerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamVolunteer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DreamVolunteer_Dreams_DreamId",
                        column: x => x.DreamId,
                        principalTable: "Dreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DreamVolunteer_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DreamVolunteer_DreamId",
                table: "DreamVolunteer",
                column: "DreamId");

            migrationBuilder.CreateIndex(
                name: "IX_DreamVolunteer_VolunteerId",
                table: "DreamVolunteer",
                column: "VolunteerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DreamVolunteer");

            migrationBuilder.AddColumn<Guid>(
                name: "DreamId",
                table: "Volunteers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_DreamId",
                table: "Volunteers",
                column: "DreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Dreams_DreamId",
                table: "Volunteers",
                column: "DreamId",
                principalTable: "Dreams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
