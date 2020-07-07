using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMM.Migrations
{
    public partial class addDreamer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dreamers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true),
                    dream = table.Column<string>(nullable: true),
                    yearOfBirth = table.Column<int>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    guardianContact = table.Column<string>(nullable: true),
                    photoAsBase64 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreamers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dreamers");
        }
    }
}
