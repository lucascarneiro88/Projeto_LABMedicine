using LABMedicine.DTO;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Enumerator;
namespace LABMedicine.DTO
{
    public class PacienteCreateDto
    {

        public int Id { get; set; }

        public string CPF { get; set; }
        public string NomeCompleto { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public string Convenio { get; set; }
        public string StatusAtendimentoEnum { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
    }
}





