﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplicationECOM.Data;

#nullable disable

namespace WebApplicationECOM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationECOM.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookCoverId")
                        .HasColumnType("integer");

                    b.Property<string>("BookUrl")
                        .HasColumnType("text");

                    b.Property<int?>("BookWriterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ISBNNUMBER")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("Trending")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("BookCoverId");

                    b.HasIndex("BookWriterId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WebApplicationECOM.Models.BookCover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookWriterId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookWriterId");

                    b.ToTable("BookCovers");
                });

            modelBuilder.Entity("WebApplicationECOM.Models.BookWriter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookWriters");
                });

            modelBuilder.Entity("WebApplicationECOM.Models.Book", b =>
                {
                    b.HasOne("WebApplicationECOM.Models.BookCover", null)
                        .WithMany("Books")
                        .HasForeignKey("BookCoverId");

                    b.HasOne("WebApplicationECOM.Models.BookWriter", null)
                        .WithMany("Books")
                        .HasForeignKey("BookWriterId");
                });

            modelBuilder.Entity("WebApplicationECOM.Models.BookCover", b =>
                {
                    b.HasOne("WebApplicationECOM.Models.BookWriter", null)
                        .WithMany("BookCovers")
                        .HasForeignKey("BookWriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationECOM.Models.BookCover", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WebApplicationECOM.Models.BookWriter", b =>
                {
                    b.Navigation("BookCovers");

                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
