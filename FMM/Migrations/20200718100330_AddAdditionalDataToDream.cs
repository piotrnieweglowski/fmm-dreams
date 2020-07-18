using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FMM.Migrations
{
    public partial class AddAdditionalDataToDream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreamers_Dreams_DreamId",
                table: "Dreamers");

            migrationBuilder.DropIndex(
                name: "IX_Dreamers_DreamId",
                table: "Dreamers");

            migrationBuilder.DropColumn(
                name: "DreamId",
                table: "Dreamers");

            migrationBuilder.AddColumn<bool>(
                name: "CanProceed",
                table: "Dreams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DreamerId",
                table: "Dreams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DreamCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DreamId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DreamCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DreamCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DreamCategory_Dreams_DreamId",
                        column: x => x.DreamId,
                        principalTable: "Dreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dreams_DreamerId",
                table: "Dreams",
                column: "DreamerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DreamCategory_CategoryId",
                table: "DreamCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DreamCategory_DreamId",
                table: "DreamCategory",
                column: "DreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreams_Dreamers_DreamerId",
                table: "Dreams",
                column: "DreamerId",
                principalTable: "Dreamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dreams_Dreamers_DreamerId",
                table: "Dreams");

            migrationBuilder.DropTable(
                name: "DreamCategory");

            migrationBuilder.DropIndex(
                name: "IX_Dreams_DreamerId",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "CanProceed",
                table: "Dreams");

            migrationBuilder.DropColumn(
                name: "DreamerId",
                table: "Dreams");

            migrationBuilder.AddColumn<Guid>(
                name: "DreamId",
                table: "Dreamers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dreamers_DreamId",
                table: "Dreamers",
                column: "DreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dreamers_Dreams_DreamId",
                table: "Dreamers",
                column: "DreamId",
                principalTable: "Dreams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
