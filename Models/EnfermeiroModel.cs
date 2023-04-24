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

        public string InstituicaoEnsinoFormacao { get; set; }//Instituição de Ensino da Formação: Obrigatório, deve ser texto.

        [Required]
        public string CadastroCOFEN { get; set; }//Cadastro do COFEN/UF: Obrigatório, deve ser texto.
    }
}
