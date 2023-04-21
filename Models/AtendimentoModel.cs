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
    }
}
