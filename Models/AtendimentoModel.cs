using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{

    [Table("ATENDIMENTO")]
    public class AtendimentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string Descricao { get; set; }//varchar max

        [Required]
        public int IdMedico { get; set; }//ver se precisa ser obrigatorio

        [ForeignKey("IdMedico")]
        public MedicoModel Medico { get; set; }

        [Required]
        public int IdPaciente { get; set; }//ver se precisa ser obrigatorio

        [ForeignKey("IdPaciente")]
        public PacienteModel Paciente { get; set; }

        //O sistema deve perguntar qual foi o médico e paciente que participaram do atendimento. O atendimento médico deve ter o Identificador do paciente.



    }
}
