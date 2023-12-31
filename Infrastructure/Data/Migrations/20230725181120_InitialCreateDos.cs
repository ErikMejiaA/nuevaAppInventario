﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreProducto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    StockMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPersonas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreEstado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodPais = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_CodPais",
                        column: x => x.CodPais,
                        principalTable: "Paises",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreRegion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodEstado = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Regiones_Estados_CodEstado",
                        column: x => x.CodEstado,
                        principalTable: "Estados",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdCodigo = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApellidoPersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPersona = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodRegion = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdCodigo);
                    table.ForeignKey(
                        name: "FK_Personas_Regiones_CodRegion",
                        column: x => x.CodRegion,
                        principalTable: "Regiones",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_TiposPersonas_IdTipoPersona",
                        column: x => x.IdTipoPersona,
                        principalTable: "TiposPersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductosPersonas",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdProducto = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPersonas", x => new { x.IdProducto, x.IdPersona });
                    table.ForeignKey(
                        name: "FK_ProductosPersonas_Personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosPersonas_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_CodPais",
                table: "Estados",
                column: "CodPais");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_NombreEstado",
                table: "Estados",
                column: "NombreEstado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_NombrePais",
                table: "Paises",
                column: "NombrePais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_CodRegion",
                table: "Personas",
                column: "CodRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EmailPersona",
                table: "Personas",
                column: "EmailPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdTipoPersona",
                table: "Personas",
                column: "IdTipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPersonas_IdPersona",
                table: "ProductosPersonas",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_CodEstado",
                table: "Regiones",
                column: "CodEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Regiones_NombreRegion",
                table: "Regiones",
                column: "NombreRegion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosPersonas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "TiposPersonas");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
