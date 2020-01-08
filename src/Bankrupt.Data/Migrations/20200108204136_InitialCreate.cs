using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bankrupt.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Round = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    WinnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGames_Players_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardHouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sequential = table.Column<int>(nullable: false),
                    PurchaseValue = table.Column<int>(nullable: false),
                    RentValue = table.Column<int>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardHouses_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Possesions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true),
                    BoardGameId = table.Column<Guid>(nullable: true),
                    BoardHouseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possesions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Possesions_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Possesions_BoardHouses_BoardHouseId",
                        column: x => x.BoardHouseId,
                        principalTable: "BoardHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Possesions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_WinnerId",
                table: "BoardGames",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardHouses_BoardGameId",
                table: "BoardHouses",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Possesions_BoardGameId",
                table: "Possesions",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Possesions_BoardHouseId",
                table: "Possesions",
                column: "BoardHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Possesions_PlayerId",
                table: "Possesions",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Possesions");

            migrationBuilder.DropTable(
                name: "BoardHouses");

            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
