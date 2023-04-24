using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class PacienteGetDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public string? Convenio { get; set; } 
        public string StatusAtendimento { get; set; }//Status de Atendimento: Um paciente pode estar com as seguintes situações:
        public string? Alergias { get; set; }//Lista de Alergias
        public string? CuidadosEspecificos { get; set; }//Lista de Cuidados Específicos

      //public int TotalAtendimentos { get; set; }//Este item é um contador que inicia em zero. Sempre que um médico realiza um atendimento este valor deve ser incrementado.
    }
}
