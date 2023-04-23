using LABMedicine.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LABMedicine.Enumerator;

using System.Drawing;
using System.Runtime.ConstrainedExecution;






namespace LABMedicine.Models
{
    [Table("MÉDICO")]
    public class MedicoModel : Pessoa
    {

        [Required]
        [MaxLength(100)]

        public string InstituicaoEnsinoFormacao { get; set; }//Instituição de Ensino da Formação: Obrigatório, deve ser texto.

        [Required]
        public string CadastroCrm { get; set; }//Cadastro do CRM/UF: Obrigatório, deve ser texto.

        [Required]
        [MaxLength(100)]

        public string Especializacao { get; set; }//Especialização Clínica: Obrigatório com as seguintes opções
                                                  //Clínico Geral,Anestesista,Dermatologia,Ginecologia,Neurologia
                                                  //Pediatria,Psiquiatria,Ortopedia
                                                 
        public string? EstadoSistema { get; set; }   //Estado no Sistema:Ativo,Inativo
        public string? TotalAtendimentosRealizados { get; set; } //Total de atendimentos realizados
                                                                //Este item é um contador que inicia em zero. Sempre que um médico realiza um atendimento este valor deve ser incrementado




       




    }
}

