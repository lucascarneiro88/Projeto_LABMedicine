using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABMedicine.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENFERMEIRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituicaoEnsinoFormacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CadastroCOFEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENFERMEIRO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MÉDICO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituicaoEnsinoFormacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CadastroCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especializacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    TotalAtendimentosRealizados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MÉDICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusPaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDeAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AguardandoAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atendido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaoAtendidio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDeAtendimentos = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAtendimentosRealizados = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ENFERMEIRO",
                columns: new[] { "Id", "CPF", "CadastroCOFEN", "DataDeNascimento", "Genero", "InstituicaoEnsinoFormacao", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { 3, "667.267.570-18", "121314", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "UFSM", "Enf. Willian Tito Silva", "91869833" },
                    { 4, "945.129.600-07", "111213", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "UFRS", "Enf. Maria Fernandes Marques", "91698534" }
                });

            migrationBuilder.InsertData(
                table: "MÉDICO",
                columns: new[] { "Id", "CPF", "CadastroCrm", "DataDeNascimento", "Especializacao", "EstadoSistema", "Genero", "InstituicaoEnsinoFormacao", "MedicoId", "NomeCompleto", "PacienteId", "Telefone", "TotalAtendimentosRealizados" },
                values: new object[,]
                {
                    { 1, "995.693.440-24", "55666/SC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clinico Geral", false, "Masculino", "UFSC", 0, "Dr. Roberto Castro Medeiros", 0, "84912333", "0" },
                    { 2, "864.204.910-37", "99666/RS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ortopedista", false, "Feminino", "UFSM", 0, "Dra. Alessandra Souza dos Santos", 0, "98653256", "0" }
                });

            migrationBuilder.InsertData(
                table: "PACIENTE",
                columns: new[] { "Id", "AguardandoAtendimento", "Atendido", "CPF", "ContatoDeEmergencia", "DataDeNascimento", "EmAtendimento", "Genero", "NaoAtendidio", "NomeCompleto", "StatusDeAtendimento", "StatusPaciente", "Telefone", "TotalDeAtendimentos" },
                values: new object[,]
                {
                    { 5, "Sim", "Não", "578.330.130-21", "Gustavo 54283", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Masculino", null, "Pcte.Saulo da Silva", "Aguardando atendimento", "Ativo", "84759836", 0 },
                    { 6, "Sim", "Não", "385.486.870-70", "Juliana 289713", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Masculino", null, "Pcte. Humberto José Teixeira", "Aguardando atendimento", "Ativo", "97563986", 0 },
                    { 7, "Não", "Não", "764.712.840-04", "Gabriela 987654", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Feminino", null, "Pcte. Vanessa Torres ", "Aguardando atendimento", "Ativo", "84579683", 0 },
                    { 8, "Não", "Não", "167.149.340-09", "Mateus 674924", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Masculino", null, "Pcte. Marcio Guedes", "Aguardando atendimento", "Ativo", "84579685", 0 },
                    { 9, "Não", "Não", "721.149.230-96", "Fernanda 321654", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Feminino", null, "Pcte. Maria Aparecida Souza", "Aguardando atendimento", "Ativo", "84593698", 0 },
                    { 10, "Sim", "Não", "647.142.010-26", "Maria 15698", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Maculino", null, "Pcte. Henrique Marques Soares", "Aguardando atendimento", "Ativo", "91689365", 0 },
                    { 11, "Sim", "Sim", "628.234.450-64", "Mario 56984", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Feminino", null, "Pcte. Francisca Almeida dos Santos", "Aguardando atendimento", "Ativo", "91642537", 0 },
                    { 12, "Sim", "Sim", "628.234.450-64", "Sergio 58479", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Masculino", null, "Pcte. João Maria da Silva", "Aguardando atendimento", "Ativo", "91989693", 0 },
                    { 13, "Sim", "Sim", "781.389.900-82", "Gertrude 47892", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Não", "Masculino", null, "Pcte. Alexandre Mattos", "Aguardando atendimento", "Ativo", "96939291", 0 },
                    { 14, "Sim", "Sim", "677.746.870-68", "Cesar 548915", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sim", "Feminino", null, "Pcte. Vitória Mengue", "Aguardando atendimento", "Ativo", "97989495", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENFERMEIRO");

            migrationBuilder.DropTable(
                name: "MÉDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
