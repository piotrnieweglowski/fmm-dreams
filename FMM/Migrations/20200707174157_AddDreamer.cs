using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMM.Migrations
{
    public partial class AddDreamer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Dreamers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    DreamId = table.Column<Guid>(nullable: true),
                    YearOfBirth = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    GuardianContact = table.Column<string>(nullable: true),
                    PhotoAsBase64 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreamers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dreamers_Dreams_DreamId",
                        column: x => x.DreamId,
                        principalTable: "Dreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dreamers_DreamId",
                table: "Dreamers",
                column: "DreamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dreamers");

        }
    }
}
