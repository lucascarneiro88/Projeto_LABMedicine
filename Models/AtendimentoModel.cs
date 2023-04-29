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

        [MaxLength]
        public string Descricao { get; set; }

        [Required]
        [ForeignKey("IdMedico")]
        public int IdMedico { get; set; }
       
        [Required]
        [ForeignKey("IdPaciente")]
        public int IdPaciente { get; set; }
    }
}
