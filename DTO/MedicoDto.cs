using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class MedicoDto
    {
        public int  Id { get; set; }
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string DataDeNascimento { get; set; }
        public string Telefone { get; set; }
      
        public string InstituicaoEnsinoFormacao { get; set;}
        public EspecializacaoMedicoEnum Especializacao { get; set; }
        public EstadoSistemaEnum EstadoSistema { get; set; }
        public string TotalAtendimentosRealizados { get; set; }
        public string CadastroCrm { get; set; }


    }
}

