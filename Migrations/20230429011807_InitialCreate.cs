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
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENFERMEIRO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstituicaoEnsinoFormacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CadastroCrm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especializacao = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    EstadoSistema = table.Column<int>(type: "int", nullable: false),
                    TotalAtendimentosRealizados = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuidadosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusAtendimento = table.Column<int>(type: "int", nullable: false),
                    TotalAtendimentos = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATENDIMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATENDIMENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_MEDICO_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATENDIMENTO_PACIENTE_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ENFERMEIRO",
                columns: new[] { "Id", "CPF", "CadastroCOFEN", "DataDeNascimento", "Genero", "InstituicaoEnsinoFormacao", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { 3, "667.267.570-18", "121314", "05/06/1984", "Masculino", "UFSM", "Willian Tito Silva", "91869833" },
                    { 4, "945.129.600-07", "111213", "06/04/1992", "Feminino", "UFRS", "Maria Fernandes Marques", "91698534" }
                });

            migrationBuilder.InsertData(
                table: "MEDICO",
                columns: new[] { "Id", "CPF", "CadastroCrm", "DataDeNascimento", "Especializacao", "EstadoSistema", "Genero", "InstituicaoEnsinoFormacao", "NomeCompleto", "Telefone", "TotalAtendimentosRealizados" },
                values: new object[,]
                {
                    { 1, "995.693.440-24", "55666/SC", "02/02/1986", 0, 0, "Masculino", "UFSC", " Roberto Castro Medeiros", "84912333", 2 },
                    { 2, "864.204.910-37", "99666/RS", "01/05/1979", 7, 0, "Feminino", "UFSM", " Alessandra Souza dos Santos", "98653256", 0 }
                });

            migrationBuilder.InsertData(
                table: "PACIENTE",
                columns: new[] { "Id", "Alergias", "CPF", "ContatoDeEmergencia", "Convenio", "CuidadosEspecificos", "DataDeNascimento", "Genero", "NomeCompleto", "StatusAtendimento", "Telefone", "TotalAtendimentos" },
                values: new object[,]
                {
                    { 5, "não possui alergias", "578.330.130-21", "Gustavo 84925428", "Simed", "não necessita ", "02/01/1990", "Masculino", "Saulo da Silva", 3, "84759836", 2 },
                    { 6, "Alergico a Camarão | Rinite", "385.486.870-70", "Juliana 91289713", "Sulmed", "não necessita ", "13/04/1977", "Masculino", "Humberto José Teixeira", 2, "97563986", 2 },
                    { 7, "não possui alergias", "764.712.840-04", "Gabriela 98765400", "Unimed", "não necessita ", "26/01/1983", "Feminino", "Vanessa Torres ", 3, "84579683", 2 },
                    { 8, "não possui alergias", "167.149.340-09", "Mateus 94674924", "Help", "não necessita ", "16/04/1973", "Masculino", "Marcio Guedes", 2, "84579685", 1 },
                    { 9, "não possui alergias", "721.149.230-96", "Fernanda 3214654", "Simed", "não necessita ", "11/02/1998", "Feminino", "Maria Aparecida Souza", 0, "84593698", 2 },
                    { 10, null, "647.142.010-26", "Maria 98515698", "Sulmed", null, "17/02/1969", "Maculino", "Henrique Marques Soares", 0, "91689365", 0 },
                    { 11, "não possui alergias", "628.234.450-64", "Mario 97556984", "Simed", "não necessita ", "01/03/2005", "Feminino", "Francisca Almeida dos Santos", 0, "91642537", 3 },
                    { 12, "não possui alergias", "628.234.450-64", "Sergio 88658479", "unimed", "não necessita ", "15/04/2003", "Masculino", "João Maria da Silva", 0, "91989693", 2 },
                    { 13, "não possui alergias", "781.389.900-82", "Gertrude 84547892", "Help", "não necessita ", "04/02/1970", "Masculino", "Alexandre Mattos", 0, "96939291", 4 },
                    { 14, "não possui alergias", "677.746.870-68", "Cesar 84548915", "Unimed", "não necessita ", "01/04/1988", "Feminino", "Vitória Mengue", 2, "97989495", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_IdMedico",
                table: "ATENDIMENTO",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_ATENDIMENTO_IdPaciente",
                table: "ATENDIMENTO",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "ENFERMEIRO");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
