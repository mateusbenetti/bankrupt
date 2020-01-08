using Bankrupt.Data.Context;
using Bankrupt.Data.Model.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Bankrupt.Data.Migrations
{
    public partial class AddPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Players", new string[] { "Id", "Type", "Name" }, new object[] { Guid.NewGuid(), 0, "None" });
            migrationBuilder.InsertData("Players", new string[] { "Id", "Type", "Name" }, new object[] { Guid.NewGuid(), 1, "Random" });
            migrationBuilder.InsertData("Players", new string[] { "Id", "Type", "Name" }, new object[] { Guid.NewGuid(), 2, "Impulsive" });
            migrationBuilder.InsertData("Players", new string[] { "Id", "Type", "Name" }, new object[] { Guid.NewGuid(), 3, "Cautious" });
            migrationBuilder.InsertData("Players", new string[] { "Id", "Type", "Name" }, new object[] { Guid.NewGuid(), 4, "Demanding" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Players");
        }
    }
}
