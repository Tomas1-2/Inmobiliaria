﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inmobiliaria.Migrations
{
    [DbContext(typeof(inmobiliariaContext))]
    [Migration("20221105071357_RentalCasa")]
    partial class RentalCasa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inmobiliaria.Models.Casa", b =>
                {
                    b.Property<int>("casaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("casaID"), 1L, 1);

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<byte[]>("imagen")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("nombreCasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreDueño")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("casaID");

                    b.ToTable("Casa");
                });

            modelBuilder.Entity("Inmobiliaria.Models.Cliente", b =>
                {
                    b.Property<int>("clienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clienteID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalCasa", b =>
                {
                    b.Property<int>("RentalCasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalCasaId"), 1L, 1);

                    b.Property<int>("CasaID")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlquiler")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalCasaId");

                    b.HasIndex("CasaID");

                    b.HasIndex("ClienteId");

                    b.ToTable("RentalCasa");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalDetail", b =>
                {
                    b.Property<int>("RentalDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailID"), 1L, 1);

                    b.Property<int>("RentalCasaId")
                        .HasColumnType("int");

                    b.Property<int>("casaID")
                        .HasColumnType("int");

                    b.Property<string>("nombreCasa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalDetailID");

                    b.HasIndex("RentalCasaId");

                    b.HasIndex("casaID");

                    b.ToTable("RentalDetail");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalDetailTemp", b =>
                {
                    b.Property<int>("RentalDetailTempID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalDetailTempID"), 1L, 1);

                    b.Property<int>("casaID")
                        .HasColumnType("int");

                    b.Property<string>("nombreCasa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalDetailTempID");

                    b.ToTable("RentalDetailTemp");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalCasa", b =>
                {
                    b.HasOne("Inmobiliaria.Models.Casa", "Casa")
                        .WithMany()
                        .HasForeignKey("CasaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casa");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalDetail", b =>
                {
                    b.HasOne("Inmobiliaria.Models.RentalCasa", "RentalCasa")
                        .WithMany("RentalDetails")
                        .HasForeignKey("RentalCasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inmobiliaria.Models.Casa", "Casa")
                        .WithMany()
                        .HasForeignKey("casaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casa");

                    b.Navigation("RentalCasa");
                });

            modelBuilder.Entity("Inmobiliaria.Models.RentalCasa", b =>
                {
                    b.Navigation("RentalDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
