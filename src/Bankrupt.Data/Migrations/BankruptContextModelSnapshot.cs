﻿// <auto-generated />
using System;
using Bankrupt.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bankrupt.Data.Migrations
{
    [DbContext(typeof(BankruptContext))]
    partial class BankruptContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Bankrupt.Data.Model.BoardHouseInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BoardGameId");

                    b.Property<int>("PurchaseValue");

                    b.Property<int>("RentValue");

                    b.Property<int>("Sequential");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.ToTable("BoardHouses");
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

            modelBuilder.Entity("Bankrupt.Data.Model.PossesionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BoardGameId");

                    b.Property<Guid?>("BoardHouseId");

                    b.Property<Guid?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("BoardHouseId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Possesions");
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

            modelBuilder.Entity("Bankrupt.Data.Model.BoardHouseInfo", b =>
                {
                    b.HasOne("Bankrupt.Data.Model.BoardGameInfo", "BoardGame")
                        .WithMany("BoardHouses")
                        .HasForeignKey("BoardGameId");
                });

            modelBuilder.Entity("Bankrupt.Data.Model.PossesionInfo", b =>
                {
                    b.HasOne("Bankrupt.Data.Model.BoardGameInfo", "BoardGame")
                        .WithMany()
                        .HasForeignKey("BoardGameId");

                    b.HasOne("Bankrupt.Data.Model.BoardHouseInfo", "BoardHouse")
                        .WithMany()
                        .HasForeignKey("BoardHouseId");

                    b.HasOne("Bankrupt.Data.Model.PlayerInfo", "Player")
                        .WithMany("Possesions")
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
