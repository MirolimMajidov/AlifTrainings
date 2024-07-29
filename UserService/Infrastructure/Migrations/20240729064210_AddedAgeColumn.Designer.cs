﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserService.Infrastructure;

#nullable disable

namespace UserService.Infrastructure.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20240729064210_AddedAgeColumn")]
    partial class AddedAgeColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("MyUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("eac40fd2-151d-473a-80fc-a0807fa5941b"),
                            Age = 23,
                            FirstName = "Ali",
                            LastName = "Valiev"
                        },
                        new
                        {
                            Id = new Guid("a37d0ad9-63ce-481c-a141-c93bc1099045"),
                            Age = 87,
                            FirstName = "James",
                            LastName = "Esh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
