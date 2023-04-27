using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Base;
using LABMedicine.Enumerator;

namespace LABMedicine.Models
{
    
    
        [Table("PACIENTE")]
        public class PacienteModel : Pessoa
        {
            [Required]
            [MaxLength(100)]
            public string ContatoDeEmergencia { get; set; }
                                                           
            [MaxLength]
            public string? Alergias { get; set; }//Lista de Alergias

            [MaxLength]
            public string? CuidadosEspecificos { get; set; }//Lista de Cuidados Específicos
            public string? Convenio { get; set; } 
            
            public StatusAtendimentoEnum StatusAtendimento { get; set; }
            
            public string TotalAtendimentos { get; set; }

        }


   
}







