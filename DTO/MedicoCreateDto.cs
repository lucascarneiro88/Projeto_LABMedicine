using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class MedicoCreateDto
    {
        public int  Id { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string InstituicaoEnsinoFormacao { get; set;}
        public string Especializacao { get; set; }
        public string EstadoSistemaEnum { get; set; }
        public string TotalAtendimentosRealizados { get; set; }
        public string Telefone { get; set; }
        public string DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public string CadastroCrm { get; set; }


    }
}

