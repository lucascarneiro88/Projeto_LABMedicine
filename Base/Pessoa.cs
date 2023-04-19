using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LABMedicine.Base
{
    public class Pessoa
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }//        Identificador: Um número que deve ser incrementado automaticamente

        [MaxLength(100)]
        public string NomeCompleto { get; set; }//Nome Completo: Deve ser um texto
        public string? Genero { get; set; }//Gênero: Deve ser um texto

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public string DataDeNascimento { get; set; }  //Data de Nascimento: Obrigatório, data válida.
        public string? CPF { get; set; }//CPF: Deve ser texto

        public string? Telefone { get; set; }//Telefone: Deve ser texto
        
    }
}
