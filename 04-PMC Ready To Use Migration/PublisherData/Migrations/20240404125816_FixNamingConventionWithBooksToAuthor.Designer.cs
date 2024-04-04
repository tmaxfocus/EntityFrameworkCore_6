﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublisherData;

#nullable disable

namespace PublisherData.Migrations
{
    [DbContext(typeof(PubCOntext))]
    [Migration("20240404125816_FixNamingConventionWithBooksToAuthor")]
    partial class FixNamingConventionWithBooksToAuthor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PublisherDomain.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Rhoda",
                            LastName = "Lerman"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Tobi",
                            LastName = "Adelabi"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Bolaji",
                            LastName = "Kolade"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Olaogunwa",
                            LastName = "Jolatito"
                        },
                        new
                        {
                            AuthorId = 5,
                            FirstName = "Felixo",
                            LastName = "Idiagbongan"
                        });
                });

            modelBuilder.Entity("PublisherDomain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            BasePrice = 0m,
                            PublishDate = new DateTime(1989, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "In God's Ear"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            BasePrice = 0m,
                            PublishDate = new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Tale For the Time Being"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3,
                            BasePrice = 0m,
                            PublishDate = new DateTime(1996, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Right Hand Of Godr"
                        });
                });

            modelBuilder.Entity("PublisherDomain.Book", b =>
                {
                    b.HasOne("PublisherDomain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PublisherDomain.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}