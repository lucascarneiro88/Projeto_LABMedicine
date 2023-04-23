using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





namespace LABMedicine.Models
{
    public class BancoDadosContext : DbContext
    {
        public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options) { }

        public DbSet<PacienteModel> Paciente { get; set; }
        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<EnfermeiroModel> Enfermeiro { get; set; }
        public DbSet<AtendimentoModel> Atendimento { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<MedicoModel>().HasData(
                new MedicoModel
                {
                    Id = 1,
                    NomeCompleto = "Dr. Roberto Castro Medeiros",
                    Genero = "Masculino",
                    DataDeNascimento = "02/02/1986",
                    CPF = "995.693.440-24",
                    Telefone = "84912333",
                    InstituicaoEnsinoFormacao = "UFSC",
                    CadastroCrm = "55666/SC",
                    Especializacao = "Clinico Geral",
                    TotalAtendimentosRealizados = "0"
                },
                new MedicoModel
                {
                    Id = 2,
                    NomeCompleto = "Dra. Alessandra Souza dos Santos",
                    Genero = "Feminino",
                    DataDeNascimento = "01/05/1979",
                    CPF = "864.204.910-37",
                    Telefone = "98653256",
                    InstituicaoEnsinoFormacao = "UFSM",
                    CadastroCrm = "99666/RS",
                    Especializacao = "Ortopedista",
                    TotalAtendimentosRealizados = "0"
                }


               );

            modelBuilder.Entity<EnfermeiroModel>().HasData(
                new EnfermeiroModel
                {
                    Id = 3,
                    NomeCompleto = "Enf. Willian Tito Silva",
                    Genero = "Masculino",
                    DataDeNascimento = "05/06/1984",
                    CPF = "667.267.570-18",
                    Telefone = "91869833",
                    CadastroCOFEN = "121314",
                    InstituicaoEnsinoFormacao = "UFSM"
                },
                new EnfermeiroModel
                {
                    Id = 4,
                    NomeCompleto = "Enf. Maria Fernandes Marques",
                    Genero = "Feminino",
                    DataDeNascimento = "06/04/1992",
                    CPF = "945.129.600-07",
                    Telefone = "91698534",
                    CadastroCOFEN = "111213",
                    InstituicaoEnsinoFormacao = "UFRS"
                }

            );
            modelBuilder.Entity<PacienteModel>().HasData(
               new PacienteModel
               {
                   Id = 5,
                   NomeCompleto = "Pcte.Saulo da Silva",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Masculino",
                   DataDeNascimento = "02/01/1990",
                   CPF = "578.330.130-21",
                   Telefone = "84759836",
                   ContatoDeEmergencia = "Gustavo 84925428",
                   Convenio = "Simed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 2

               },
               new PacienteModel
               {
                   Id = 6,
                   NomeCompleto = "Pcte. Humberto José Teixeira",
                   Alergias = "Alergico a Camarão | Rinite",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Masculino",
                   DataDeNascimento = "13/04/1977",
                   CPF = "385.486.870-70",
                   Telefone = "97563986",
                   ContatoDeEmergencia = "Juliana 91289713",
                   Convenio = "Sulmed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 2 



               },
               new PacienteModel
               {
                   Id = 7,
                   NomeCompleto = "Pcte. Vanessa Torres ",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Feminino",
                   DataDeNascimento = "26/01/1983",
                   CPF = "764.712.840-04",
                   Telefone = "84579683",
                   ContatoDeEmergencia = "Gabriela 98765400",
                   Convenio = "Unimed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 2

               },
               new PacienteModel
               {
                   Id = 8,
                   NomeCompleto = "Pcte. Marcio Guedes",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Masculino",
                   DataDeNascimento = "16/04/1973",
                   CPF = "167.149.340-09",
                   Telefone = "84579685",
                   ContatoDeEmergencia = "Mateus 94674924",
                   Convenio = "Help",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 1

               },
               new PacienteModel
               {
                   Id = 9,
                   NomeCompleto = "Pcte. Maria Aparecida Souza",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Feminino",
                   DataDeNascimento = "11/02/1998",
                   CPF = "721.149.230-96",
                   Telefone = "84593698",
                   ContatoDeEmergencia = "Fernanda 3214654",
                   Convenio = "Simed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 2
                   
               },
               new PacienteModel
               {
                   Id = 10,
                   NomeCompleto = "Pcte. Henrique Marques Soares",
                   Genero = "Maculino",
                   DataDeNascimento = "17/02/1969",
                   CPF = "647.142.010-26",
                   Telefone = "91689365",
                   ContatoDeEmergencia = "Maria 98515698",
                   Convenio = "Sulmed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 0



               },
               new PacienteModel
               {
                   Id = 11,
                   NomeCompleto = "Pcte. Francisca Almeida dos Santos",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Feminino",
                   DataDeNascimento = "01/03/2005",
                   CPF = "628.234.450-64",
                   Telefone = "91642537",
                   ContatoDeEmergencia = "Mario 97556984",
                   Convenio = "Simed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 3

               },
               new PacienteModel
               {
                   Id = 12,
                   NomeCompleto = "Pcte. João Maria da Silva",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Masculino",
                   DataDeNascimento = "15/04/2003",
                   CPF = "628.234.450-64",
                   Telefone = "91989693",
                   ContatoDeEmergencia = "Sergio 88658479",
                   Convenio = "unimed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 2

               },
               new PacienteModel
               {
                   Id = 13,
                   NomeCompleto = "Pcte. Alexandre Mattos",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Masculino",
                   DataDeNascimento = "04/02/1970",
                   CPF = "781.389.900-82",
                   Telefone = "96939291",
                   ContatoDeEmergencia = "Gertrude 84547892",
                   Convenio = "Help",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 1

               },
               new PacienteModel
               {
                   Id = 14,
                   NomeCompleto = "Pcte. Vitória Mengue",
                   Alergias = "não possui alergias",
                   CuidadosEspecificos = "não necessita ",
                   Genero = "Feminino",
                   DataDeNascimento = "01/04/1988",
                   CPF = "677.746.870-68",
                   Telefone = "97989495",
                   ContatoDeEmergencia = "Cesar 84548915",
                   Convenio = "Unimed",
                   StatusAtendimento = "Aguardando atendimento",
                   TotalAtendimentos = 0

               }

           );
        }
    }
}

