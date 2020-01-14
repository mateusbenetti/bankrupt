﻿// <auto-generated />
using System;
using Bankrupt.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bankrupt.Data.Migrations
{
    [DbContext(typeof(BankruptContext))]
    [Migration("20200112205736_AddRoundRegisterInfo")]
    partial class AddRoundRegisterInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bankrupt.Data.Model.BoardGameInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NumberRound");

                    b.Property<string>("RegisterCode");

                    b.Property<Guid>("StatisticalAnalysisId");

                    b.Property<Guid>("WinnerId");

                    b.HasKey("Id");

                    b.HasIndex("StatisticalAnalysisId");

                    b.HasIndex("WinnerId");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("Bankrupt.Data.Model.PlayerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Bankrupt.Data.Model.RoundRegisterInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<Guid>("BoardGameId");

                    b.Property<int>("BoardHouseAfter");

                    b.Property<int>("BoardHouseBefore");

                    b.Property<int>("CoinsAfter");

                    b.Property<int>("CoinsBefore");

                    b.Property<Guid>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("RoundRegisters");
                });

            modelBuilder.Entity("Bankrupt.Data.Model.StatisticalAnalysisInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("RegisterCode");

                    b.HasKey("Id");

                    b.ToTable("StatisticalAnalysis");
                });

            modelBuilder.Entity("Bankrupt.Data.Model.BoardGameInfo", b =>
                {
                    b.HasOne("Bankrupt.Data.Model.StatisticalAnalysisInfo", "StatisticalAnalysis")
                        .WithMany("BoardGames")
                        .HasForeignKey("StatisticalAnalysisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bankrupt.Data.Model.PlayerInfo", "Winner")
                        .WithMany("GamesWins")
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bankrupt.Data.Model.RoundRegisterInfo", b =>
                {
                    b.HasOne("Bankrupt.Data.Model.BoardGameInfo", "BoardGameInfo")
                        .WithMany("RoundRegisters")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bankrupt.Data.Model.PlayerInfo", "PlayerInfo")
                        .WithMany("RoundRegisters")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
