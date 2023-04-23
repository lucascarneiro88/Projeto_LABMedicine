using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Base;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using LABMedicine.Enumerator;

namespace LABMedicine.Models
{
    
    
        [Table("Paciente")]
        public class PacienteModel : Pessoa
        {
            [Required]
            [MaxLength(100)]
            public string ContatoDeEmergencia { get; set; }//Contato de Emergência: Obrigatório, Deve ser texto
                                                           //listas vai ser um varchar max
            [MaxLength]
            public string? Alergias { get; set; }//Lista de Alergias: Não obrigatório para a criação da classe

            [MaxLength]
            public string? CuidadosEspecificos { get; set; }//Lista de Cuidados Específicos: Não obrigatório para a criação da classe
            public string? Convenio { get; set; } //Convênio: Não obrigatório para a criação da classe

            public string StatusAtendimento { get; set; }//Status de Atendimento: Um paciente pode estar com as seguintes situações:
            
            //public int TotalAtendimentos { get; set; }//Este item é um contador que inicia em zero. Sempre que um médico realiza um atendimento este valor deve ser incrementado.

    }


   
}







