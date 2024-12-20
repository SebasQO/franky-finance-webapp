﻿// <auto-generated />
using System;
using FrankyFinance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FrankyFinance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241106005820_CreateUser3")]
    partial class CreateUser3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FrankyFinance.Models.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("FrankyFinance.Models.GastoCompartido", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("GastoId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("MontoAPagar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Pagado")
                        .HasColumnType("bit");

                    b.HasKey("UsuarioId", "GastoId");

                    b.HasIndex("GastoId");

                    b.ToTable("GastosCompartidos");
                });

            modelBuilder.Entity("FrankyFinance.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("FrankyFinance.Models.MiembroGrupo", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "GrupoId");

                    b.HasIndex("GrupoId");

                    b.ToTable("MiembrosGrupos");
                });

            modelBuilder.Entity("FrankyFinance.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("FrankyFinance.Models.Gasto", b =>
                {
                    b.HasOne("FrankyFinance.Models.Grupo", "Grupo")
                        .WithMany("Gastos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("FrankyFinance.Models.GastoCompartido", b =>
                {
                    b.HasOne("FrankyFinance.Models.Gasto", "Gasto")
                        .WithMany("Participantes")
                        .HasForeignKey("GastoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrankyFinance.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gasto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FrankyFinance.Models.Grupo", b =>
                {
                    b.HasOne("FrankyFinance.Models.Usuario", null)
                        .WithMany("Grupos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("FrankyFinance.Models.MiembroGrupo", b =>
                {
                    b.HasOne("FrankyFinance.Models.Grupo", "Grupo")
                        .WithMany("Miembros")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrankyFinance.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FrankyFinance.Models.Gasto", b =>
                {
                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("FrankyFinance.Models.Grupo", b =>
                {
                    b.Navigation("Gastos");

                    b.Navigation("Miembros");
                });

            modelBuilder.Entity("FrankyFinance.Models.Usuario", b =>
                {
                    b.Navigation("Grupos");
                });
#pragma warning restore 612, 618
        }
    }
}
