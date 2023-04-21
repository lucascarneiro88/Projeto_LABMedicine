using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{

    [Table("ATENDIMENTO")]
    public class AtendimentoModel
    {
        [MaxLength]
        public string descricao { get; set; }//varchar max
        public int IdMedico{ get; set; }//ver se precisa ser obrigatorio
        public int IdPaciente { get; set; }//ver se precisa ser obrigatorio

       //O sistema deve perguntar qual foi o médico e paciente que participaram do atendimento. O atendimento médico deve ter o Identificador do paciente.

        

    }
}
