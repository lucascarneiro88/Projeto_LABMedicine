﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "ATENDIMENTO",
                columns: table => new
                {
                    descricao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTO", x => x.descricao);
                });

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
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    EstadoSistema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAtendimentosRealizados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MÉDICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuidadosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ENFERMEIRO",
                columns: new[] { "Id", "CPF", "CadastroCOFEN", "DataDeNascimento", "Genero", "InstituicaoEnsinoFormacao", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { 3, "667.267.570-18", "121314", "05/06/1984", "Masculino", "UFSM", "Enf. Willian Tito Silva", "91869833" },
                    { 4, "945.129.600-07", "111213", "06/04/1992", "Feminino", "UFRS", "Enf. Maria Fernandes Marques", "91698534" }
                });

            migrationBuilder.InsertData(
                table: "MÉDICO",
                columns: new[] { "Id", "CPF", "CadastroCrm", "DataDeNascimento", "Especializacao", "EstadoSistema", "Genero", "InstituicaoEnsinoFormacao", "NomeCompleto", "Telefone", "TotalAtendimentosRealizados" },
                values: new object[,]
                {
                    { 1, "995.693.440-24", "55666/SC", "02/02/1986", "Clinico Geral", null, "Masculino", "UFSC", "Dr. Roberto Castro Medeiros", "84912333", "0" },
                    { 2, "864.204.910-37", "99666/RS", "01/05/1979", "Ortopedista", null, "Feminino", "UFSM", "Dra. Alessandra Souza dos Santos", "98653256", "0" }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Id", "Alergias", "CPF", "ContatoDeEmergencia", "Convenio", "CuidadosEspecificos", "DataDeNascimento", "Genero", "NomeCompleto", "StatusAtendimento", "Telefone" },
                values: new object[,]
                {
                    { 5, null, "578.330.130-21", "Gustavo 84925428", "Simed", null, "02/01/1990", "Masculino", "Pcte.Saulo da Silva", "Aguardando atendimento", "84759836" },
                    { 6, null, "385.486.870-70", "Juliana 91289713", "Sulmed", null, "13/04/1977", "Masculino", "Pcte. Humberto José Teixeira", "Aguardando atendimento", "97563986" },
                    { 7, null, "764.712.840-04", "Gabriela 98765400", "Unimed", null, "26/01/1983", "Feminino", "Pcte. Vanessa Torres ", "Aguardando atendimento", "84579683" },
                    { 8, null, "167.149.340-09", "Mateus 94674924", "Help", null, "16/04/1973", "Masculino", "Pcte. Marcio Guedes", "Aguardando atendimento", "84579685" },
                    { 9, null, "721.149.230-96", "Fernanda 3214654", "Simed", null, "11/02/1998", "Feminino", "Pcte. Maria Aparecida Souza", "Aguardando atendimento", "84593698" },
                    { 10, null, "647.142.010-26", "Maria 98515698", "Sulmed", null, "17/02/1969", "Maculino", "Pcte. Henrique Marques Soares", "Aguardando atendimento", "91689365" },
                    { 11, null, "628.234.450-64", "Mario 97556984", "Simed", null, "01/03/2005", "Feminino", "Pcte. Francisca Almeida dos Santos", "Aguardando atendimento", "91642537" },
                    { 12, null, "628.234.450-64", "Sergio 88658479", "unimed", null, "15/04/2003", "Masculino", "Pcte. João Maria da Silva", "Aguardando atendimento", "91989693" },
                    { 13, null, "781.389.900-82", "Gertrude 84547892", "Help", null, "04/02/1970", "Masculino", "Pcte. Alexandre Mattos", "Aguardando atendimento", "96939291" },
                    { 14, null, "677.746.870-68", "Cesar 84548915", "Unimed", null, "01/04/1988", "Feminino", "Pcte. Vitória Mengue", "Aguardando atendimento", "97989495" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "ENFERMEIRO");

            migrationBuilder.DropTable(
                name: "MÉDICO");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}