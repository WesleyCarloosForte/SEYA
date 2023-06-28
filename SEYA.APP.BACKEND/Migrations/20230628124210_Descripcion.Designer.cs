﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEYA.APP.BACKEND.Data;

#nullable disable

namespace SEYA.APP.BACKEND.Migrations
{
    [DbContext(typeof(ServerContex))]
    [Migration("20230628124210_Descripcion")]
    partial class Descripcion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SEYA.APP.Shared.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CuentaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<bool>("Pendiente")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Deuda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadCuotas")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NumeroComprobante")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Deudas");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Funcionarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Administrador",
                            Cedula = "0.000.000",
                            Correo = "administrador@gmail.com",
                            Direccion = "CDE",
                            Nombre = "Administrador del sistema",
                            Password = "123456",
                            RolId = 1,
                            Telefono = "0985555530",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comprobante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CuotaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuotaId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RolName = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            RolName = "Funcionario"
                        });
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Cuota", b =>
                {
                    b.HasOne("SEYA.APP.Shared.Models.Deuda", "Deuda")
                        .WithMany("Cuotas")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deuda");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Deuda", b =>
                {
                    b.HasOne("SEYA.APP.Shared.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Funcionario", b =>
                {
                    b.HasOne("SEYA.APP.Shared.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Pago", b =>
                {
                    b.HasOne("SEYA.APP.Shared.Models.Cuota", "Cuota")
                        .WithMany()
                        .HasForeignKey("CuotaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cuota");
                });

            modelBuilder.Entity("SEYA.APP.Shared.Models.Deuda", b =>
                {
                    b.Navigation("Cuotas");
                });
#pragma warning restore 612, 618
        }
    }
}
