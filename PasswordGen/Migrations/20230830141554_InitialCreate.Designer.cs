﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordGen.Data;

#nullable disable

namespace PasswordGen.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230830141554_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("PasswordGen.Model.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordUtente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UsernameUtente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Utente");
                });

            modelBuilder.Entity("PasswordGen.Model.Utente", b =>
                {
                    b.OwnsMany("PasswordGen.Model.PasswordModel", "PasswordList", b1 =>
                        {
                            b1.Property<int>("id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("UtenteId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("id");

                            b1.HasIndex("UtenteId");

                            b1.ToTable("PasswordList");

                            b1.WithOwner()
                                .HasForeignKey("UtenteId");
                        });

                    b.Navigation("PasswordList");
                });
#pragma warning restore 612, 618
        }
    }
}