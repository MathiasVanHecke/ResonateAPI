﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resonate.Models;

namespace Resonate.Migrations
{
    [DbContext(typeof(ResonateContext))]
    partial class ResonateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resonate.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistName");

                    b.Property<string>("HrefSpotify");

                    b.Property<string>("UrlPf");

                    b.Property<Guid>("UserId");

                    b.HasKey("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Resonate.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName");

                    b.Property<Guid>("UserId");

                    b.HasKey("GenreId");

                    b.HasIndex("UserId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Resonate.Models.Matches", b =>
                {
                    b.Property<int>("MatchesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsConfirmed");

                    b.Property<Guid>("User1");

                    b.Property<Guid>("User2");

                    b.HasKey("MatchesId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Resonate.Models.PotMatches", b =>
                {
                    b.Property<int>("PotMatchesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchLevel");

                    b.Property<string>("Name");

                    b.Property<Guid>("User1");

                    b.Property<Guid>("User2");

                    b.HasKey("PotMatchesId");

                    b.ToTable("PotMatches");
                });

            modelBuilder.Entity("Resonate.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Beschrijving");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("HrefSpotify");

                    b.Property<int>("Lat");

                    b.Property<int>("Long");

                    b.Property<string>("Name");

                    b.Property<string>("UrlPf");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Resonate.Models.Artist", b =>
                {
                    b.HasOne("Resonate.Models.User")
                        .WithMany("Artists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resonate.Models.Genre", b =>
                {
                    b.HasOne("Resonate.Models.User")
                        .WithMany("Genres")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
