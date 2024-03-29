﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tutorial.Data;

#nullable disable

namespace Tutorial.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230907121240_5th")]
    partial class _5th
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tutorial.Models.Build", b =>
                {
                    b.Property<int>("BuildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildId"));

                    b.Property<string>("BuildName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("Tutorial.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int?>("BuildId")
                        .HasColumnType("int");

                    b.Property<string>("CharacterWeaponType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Region")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("BuildId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Tutorial.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Substat")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Tutorial.Models.Build", b =>
                {
                    b.HasOne("Tutorial.Models.Weapon", "Weapons")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Weapons");
                });

            modelBuilder.Entity("Tutorial.Models.Character", b =>
                {
                    b.HasOne("Tutorial.Models.Build", "Builds")
                        .WithMany()
                        .HasForeignKey("BuildId");

                    b.Navigation("Builds");
                });
#pragma warning restore 612, 618
        }
    }
}
