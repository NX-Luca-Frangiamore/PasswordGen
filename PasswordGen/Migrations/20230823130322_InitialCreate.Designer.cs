﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordGen.Model;

#nullable disable

namespace PasswordGen.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230823130322_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("PasswordGen.Model.Password", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("utenteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("utenteId");

                    b.ToTable("passwords");
                });

            modelBuilder.Entity("PasswordGen.Model.Utente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("utente");
                });

            modelBuilder.Entity("PasswordGen.Model.Password", b =>
                {
                    b.HasOne("PasswordGen.Model.Utente", null)
                        .WithMany("passwords")
                        .HasForeignKey("utenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PasswordGen.Model.Utente", b =>
                {
                    b.Navigation("passwords");
                });
#pragma warning restore 612, 618
        }
    }
}
