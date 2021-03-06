﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BiblioDbContext))]
    [Migration("20201214104506_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("Edition")
                        .HasColumnType("integer");

                    b.Property<int>("GenreID")
                        .HasColumnType("integer");

                    b.Property<int>("Pages")
                        .HasColumnType("integer");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("BookId");

                    b.HasIndex("GenreID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorID")
                        .HasColumnType("integer");

                    b.HasKey("BookID", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookLoan", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("integer");

                    b.Property<int>("LoanID")
                        .HasColumnType("integer");

                    b.HasKey("BookID", "LoanID");

                    b.HasIndex("LoanID");

                    b.ToTable("BookLoan");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookMarketingCampaign", b =>
                {
                    b.Property<int>("BookID")
                        .HasColumnType("integer");

                    b.Property<int>("MarketingCampaignID")
                        .HasColumnType("integer");

                    b.HasKey("BookID", "MarketingCampaignID");

                    b.HasIndex("MarketingCampaignID");

                    b.ToTable("BookMarketingCampaign");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("GenreID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("returnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("LoanID");

                    b.HasIndex("UserID");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.MarketingCampaign", b =>
                {
                    b.Property<int>("MarketingCampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("discountPercentage")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("MarketingCampaignID");

                    b.ToTable("MarketingCampaign");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Book", b =>
                {
                    b.HasOne("ProjBiblio.Domain.Entities.Genre", "Genres")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookAuthor", b =>
                {
                    b.HasOne("ProjBiblio.Domain.Entities.Author", "Authors")
                        .WithMany("boAuthors")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjBiblio.Domain.Entities.Book", "Books")
                        .WithMany("boAuthors")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookLoan", b =>
                {
                    b.HasOne("ProjBiblio.Domain.Entities.Book", "Books")
                        .WithMany("boLoan")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjBiblio.Domain.Entities.Loan", "Loans")
                        .WithMany("boLoan")
                        .HasForeignKey("LoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.BookMarketingCampaign", b =>
                {
                    b.HasOne("ProjBiblio.Domain.Entities.Book", "Books")
                        .WithMany("boMarketing")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjBiblio.Domain.Entities.MarketingCampaign", "Marketings")
                        .WithMany("boMarketing")
                        .HasForeignKey("MarketingCampaignID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjBiblio.Domain.Entities.Loan", b =>
                {
                    b.HasOne("ProjBiblio.Domain.Entities.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
