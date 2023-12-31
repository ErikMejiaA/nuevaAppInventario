﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(nuevaAppInventarioContext))]
    partial class nuevaAppInventarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<string>("IdCodigo")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPais")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("CodPais");

                    b.HasIndex("NombreEstado")
                        .IsUnique();

                    b.ToTable("Estados", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<string>("IdCodigo")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("NombrePais")
                        .IsUnique();

                    b.ToTable("Paises", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.Property<string>("IdCodigo")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CodRegion")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("EmailPersona")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("NombrePersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("CodRegion");

                    b.HasIndex("EmailPersona")
                        .IsUnique();

                    b.HasIndex("IdTipoPersona");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Property<string>("IdCodigo")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal");

                    b.Property<int>("StockMaximo")
                        .HasColumnType("int");

                    b.Property<int>("StockMinimo")
                        .HasColumnType("int");

                    b.HasKey("IdCodigo");

                    b.ToTable("Productos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProductoPersona", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(3)");

                    b.HasKey("IdProducto", "IdPersona");

                    b.HasIndex("IdPersona");

                    b.ToTable("ProductosPersonas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Property<string>("IdCodigo")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodEstado")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("NombreRegion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("CodEstado");

                    b.HasIndex("NombreRegion")
                        .IsUnique();

                    b.ToTable("Regiones", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposPersonas", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("CodPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.HasOne("Core.Entities.Region", "Region")
                        .WithMany("Personas")
                        .HasForeignKey("CodRegion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entities.ProductoPersona", b =>
                {
                    b.HasOne("Core.Entities.Persona", "Persona")
                        .WithMany("ProductosPersonas")
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Producto", "Producto")
                        .WithMany("ProductosPersonas")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Regiones")
                        .HasForeignKey("CodEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("Regiones");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.Navigation("ProductosPersonas");
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Navigation("ProductosPersonas");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
