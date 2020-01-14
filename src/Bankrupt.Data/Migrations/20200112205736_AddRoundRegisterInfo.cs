using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bankrupt.Data.Migrations
{
    public partial class AddRoundRegisterInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoundRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: false),
                    BoardHouseAfter = table.Column<int>(nullable: false),
                    BoardHouseBefore = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    CoinsAfter = table.Column<int>(nullable: false),
                    CoinsBefore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoundRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoundRegisters_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoundRegisters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoundRegisters_BoardGameId",
                table: "RoundRegisters",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_RoundRegisters_PlayerId",
                table: "RoundRegisters",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoundRegisters");
        }
    }
}
