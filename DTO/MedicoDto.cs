using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using static LABMedicine.CustomValidation.CustomValidation;

namespace LABMedicine.DTO
{
    public class MedicoDto
    {
        public int  Id { get; set; }
        [Required]
        [checkCPF(ErrorMessage = "Por favor, informar um CPF válido, somente números!")]
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string DataDeNascimento { get; set; }
        public string Telefone { get; set; }
      
        public string InstituicaoEnsinoFormacao { get; set;}
        public EspecializacaoMedicoEnum Especializacao { get; set; }
        public EstadoSistemaEnum EstadoSistema { get; set; }
        public int TotalAtendimentosRealizados { get; set; }
        public string CadastroCrm { get; set; }


    }
}

