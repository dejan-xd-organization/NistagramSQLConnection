﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NistagramSQLConnection.Data;

namespace NistagramSQLConnection.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210813193856_Migrate")]
    partial class Migrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("NistagramSQLConnection.Model.Address", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("city")
                        .HasColumnType("longtext");

                    b.Property<string>("country")
                        .HasColumnType("longtext");

                    b.Property<int>("postCode")
                        .HasColumnType("int");

                    b.Property<string>("region")
                        .HasColumnType("longtext");

                    b.Property<string>("street")
                        .HasColumnType("longtext");

                    b.Property<string>("streetNumber")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.Role", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("addressid")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dateOfRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("profileImg")
                        .HasColumnType("longtext");

                    b.Property<string>("relationship")
                        .HasColumnType("longtext");

                    b.Property<long?>("roleid")
                        .HasColumnType("bigint");

                    b.Property<string>("sex")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("addressid");

                    b.HasIndex("roleid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("NistagramSQLConnection.Model.User", b =>
                {
                    b.HasOne("NistagramSQLConnection.Model.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressid");

                    b.HasOne("NistagramSQLConnection.Model.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleid");

                    b.Navigation("address");

                    b.Navigation("role");
                });
#pragma warning restore 612, 618
        }
    }
}