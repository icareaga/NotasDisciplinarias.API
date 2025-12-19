using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotasDisciplinarias.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    id_accion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caso = table.Column<int>(type: "int", nullable: false),
                    plan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_cumpl = table.Column<DateTime>(type: "datetime2", nullable: true),
                    responsable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.id_accion);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    id_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caso = table.Column<int>(type: "int", nullable: false),
                    ruta_guardado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ruta_formato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.id_documento);
                });

            migrationBuilder.CreateTable(
                name: "PanelAdmin",
                columns: table => new
                {
                    id_panel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_caso = table.Column<int>(type: "int", nullable: false),
                    acciones_realizadas = table.Column<int>(type: "int", nullable: false),
                    evidencias_subidas = table.Column<int>(type: "int", nullable: false),
                    documentos_generados = table.Column<int>(type: "int", nullable: false),
                    fecha_revision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelAdmin", x => x.id_panel);
                });

            migrationBuilder.CreateTable(
                name: "Pasos",
                columns: table => new
                {
                    id_paso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caso = table.Column<int>(type: "int", nullable: false),
                    nombre_paso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasos", x => x.id_paso);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientoProcesos",
                columns: table => new
                {
                    id_seguimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_paso = table.Column<int>(type: "int", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    responsable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientoProcesos", x => x.id_seguimiento);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_jefe_inmediato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    id_caso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estatus = table.Column<int>(type: "int", nullable: false),
                    CategoriaId_Categoria = table.Column<int>(type: "int", nullable: true),
                    UsuarioId_Usuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.id_caso);
                    table.ForeignKey(
                        name: "FK_Casos_Categorias_CategoriaId_Categoria",
                        column: x => x.CategoriaId_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "id_categoria");
                    table.ForeignKey(
                        name: "FK_Casos_Usuarios_UsuarioId_Usuario",
                        column: x => x.UsuarioId_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Evidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCaso = table.Column<int>(type: "int", nullable: false),
                    Tipo_archivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidencias_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "id_caso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casos_CategoriaId_Categoria",
                table: "Casos",
                column: "CategoriaId_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_UsuarioId_Usuario",
                table: "Casos",
                column: "UsuarioId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencias_IdCaso",
                table: "Evidencias",
                column: "IdCaso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Evidencias");

            migrationBuilder.DropTable(
                name: "PanelAdmin");

            migrationBuilder.DropTable(
                name: "Pasos");

            migrationBuilder.DropTable(
                name: "SeguimientoProcesos");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
