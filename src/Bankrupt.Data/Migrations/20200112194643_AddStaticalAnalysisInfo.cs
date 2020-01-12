using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bankrupt.Data.Migrations
{
    public partial class AddStaticalAnalysisInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "BoardGames",
                newName: "NumberRound");

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticalAnalysisId",
                table: "BoardGames",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StatisticalAnalysisInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegisterCode = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticalAnalysisInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_StatisticalAnalysisId",
                table: "BoardGames",
                column: "StatisticalAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_StatisticalAnalysisInfo_StatisticalAnalysisId",
                table: "BoardGames",
                column: "StatisticalAnalysisId",
                principalTable: "StatisticalAnalysisInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_StatisticalAnalysisInfo_StatisticalAnalysisId",
                table: "BoardGames");

            migrationBuilder.DropTable(
                name: "StatisticalAnalysisInfo");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_StatisticalAnalysisId",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "StatisticalAnalysisId",
                table: "BoardGames");

            migrationBuilder.RenameColumn(
                name: "NumberRound",
                table: "BoardGames",
                newName: "Round");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BoardGames",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
