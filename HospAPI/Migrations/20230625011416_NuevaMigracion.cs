using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospAPI.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investigaciones",
                columns: table => new
                {
                    InvestigacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Articulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigaciones", x => x.InvestigacionId);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedico = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubEspecialidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CedulaProfesional = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Estaus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaciente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NSS = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Agregado = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UMF = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposEstudios",
                columns: table => new
                {
                    TipoEstudioId = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NombreTipoEstudio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstudios", x => x.TipoEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "InvestigacionMedico",
                columns: table => new
                {
                    InvestigacionesInvestigacionId = table.Column<int>(type: "int", nullable: false),
                    MedicosMedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigacionMedico", x => new { x.InvestigacionesInvestigacionId, x.MedicosMedicoId });
                    table.ForeignKey(
                        name: "FK_InvestigacionMedico_Investigaciones_InvestigacionesInvestigacionId",
                        column: x => x.InvestigacionesInvestigacionId,
                        principalTable: "Investigaciones",
                        principalColumn: "InvestigacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestigacionMedico_Medicos_MedicosMedicoId",
                        column: x => x.MedicosMedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                columns: table => new
                {
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArchivoExpediente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.ExpedienteId);
                    table.ForeignKey(
                        name: "FK_Expedientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchivoLab = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Urea = table.Column<int>(type: "int", nullable: false),
                    Creatinina = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.LaboratorioId);
                    table.ForeignKey(
                        name: "FK_Laboratorios_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudios",
                columns: table => new
                {
                    EstudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEstudioId = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudios", x => x.EstudioId);
                    table.ForeignKey(
                        name: "FK_Etudios_TiposEstudios_TipoEstudioId",
                        column: x => x.TipoEstudioId,
                        principalTable: "TiposEstudios",
                        principalColumn: "TipoEstudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpedienteMedico",
                columns: table => new
                {
                    ExpedientesExpedienteId = table.Column<int>(type: "int", nullable: false),
                    MedicosMedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedienteMedico", x => new { x.ExpedientesExpedienteId, x.MedicosMedicoId });
                    table.ForeignKey(
                        name: "FK_ExpedienteMedico_Expedientes_ExpedientesExpedienteId",
                        column: x => x.ExpedientesExpedienteId,
                        principalTable: "Expedientes",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpedienteMedico_Medicos_MedicosMedicoId",
                        column: x => x.MedicosMedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosEstudios",
                columns: table => new
                {
                    ArchivoEstudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenDicom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosEstudios", x => x.ArchivoEstudioId);
                    table.ForeignKey(
                        name: "FK_ArchivosEstudios_Etudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Etudios",
                        principalColumn: "EstudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    ReporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporteMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReporte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstudioId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.ReporteId);
                    table.ForeignKey(
                        name: "FK_Reportes_Etudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Etudios",
                        principalColumn: "EstudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reportes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosEstudios_EstudioId",
                table: "ArchivosEstudios",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudios_TipoEstudioId",
                table: "Etudios",
                column: "TipoEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedienteMedico_MedicosMedicoId",
                table: "ExpedienteMedico",
                column: "MedicosMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_PacienteId",
                table: "Expedientes",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestigacionMedico_MedicosMedicoId",
                table: "InvestigacionMedico",
                column: "MedicosMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_PacienteId",
                table: "Laboratorios",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_EstudioId",
                table: "Reportes",
                column: "EstudioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_MedicoId",
                table: "Reportes",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_PacienteId",
                table: "Reportes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosEstudios");

            migrationBuilder.DropTable(
                name: "ExpedienteMedico");

            migrationBuilder.DropTable(
                name: "InvestigacionMedico");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Expedientes");

            migrationBuilder.DropTable(
                name: "Investigaciones");

            migrationBuilder.DropTable(
                name: "Etudios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "TiposEstudios");
        }
    }
}
