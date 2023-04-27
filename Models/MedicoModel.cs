using LABMedicine.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Enumerator;


namespace LABMedicine.Models
{
    [Table("MEDICO")]
    public class MedicoModel : Pessoa
    {

        [Required]
        [MaxLength(100)]
        public string InstituicaoEnsinoFormacao { get; set; }

        [Required]
        public string CadastroCrm { get; set; }

        [Required]
        [MaxLength(100)]
        public EspecializacaoMedicoEnum Especializacao { get; set; }
        public EstadoSistemaEnum EstadoSistema { get; set; } 
        public string TotalAtendimentosRealizados { get; set; } 
       




    }
}

