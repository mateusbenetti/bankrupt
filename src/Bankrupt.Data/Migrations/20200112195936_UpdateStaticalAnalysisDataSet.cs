using Microsoft.EntityFrameworkCore.Migrations;

namespace Bankrupt.Data.Migrations
{
    public partial class UpdateStaticalAnalysisDataSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_StatisticalAnalysisInfo_StatisticalAnalysisId",
                table: "BoardGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatisticalAnalysisInfo",
                table: "StatisticalAnalysisInfo");

            migrationBuilder.RenameTable(
                name: "StatisticalAnalysisInfo",
                newName: "StatisticalAnalysis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatisticalAnalysis",
                table: "StatisticalAnalysis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_StatisticalAnalysis_StatisticalAnalysisId",
                table: "BoardGames",
                column: "StatisticalAnalysisId",
                principalTable: "StatisticalAnalysis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_StatisticalAnalysis_StatisticalAnalysisId",
                table: "BoardGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatisticalAnalysis",
                table: "StatisticalAnalysis");

            migrationBuilder.RenameTable(
                name: "StatisticalAnalysis",
                newName: "StatisticalAnalysisInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatisticalAnalysisInfo",
                table: "StatisticalAnalysisInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_StatisticalAnalysisInfo_StatisticalAnalysisId",
                table: "BoardGames",
                column: "StatisticalAnalysisId",
                principalTable: "StatisticalAnalysisInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}