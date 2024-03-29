﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("webapi.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2022, 6, 6, 21, 28, 43, 735, DateTimeKind.Local).AddTicks(2510));

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            FechaCreacion = new DateTime(2022, 6, 6, 21, 28, 43, 735, DateTimeKind.Local).AddTicks(1000),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                            CategoriaId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            FechaCreacion = new DateTime(2022, 6, 6, 21, 28, 43, 735, DateTimeKind.Local).AddTicks(1020),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula en netflix"
                        });
                });

            modelBuilder.Entity("webapi.Models.Tarea", b =>
                {
                    b.HasOne("webapi.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("webapi.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
