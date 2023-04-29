using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using static LABMedicine.CustomValidation.CustomValidation;

namespace LABMedicine.DTO
{
    public class PacienteDto
    {
        public int Id { get; set; }
        
        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string DataDeNascimento { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public string? Convenio { get; set; } 
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        public string? Alergias { get; set; }
        public string? CuidadosEspecificos { get; set; }
        public int TotalAtendimentos { get; set; }
    }
}
