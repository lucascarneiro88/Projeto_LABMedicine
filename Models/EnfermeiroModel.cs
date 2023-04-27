using LABMedicine.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{
    [Table("ENFERMEIRO")]
    public class EnfermeiroModel : Pessoa
    {
        [Required]
        [MaxLength(100)]
        public string InstituicaoEnsinoFormacao { get; set; }

        [Required]
        public string CadastroCOFEN { get; set; }
    }
}
