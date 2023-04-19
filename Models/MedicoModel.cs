﻿using LABMedicine.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
                                                 
        public bool EstadoSistema { get; set; }   //Estado no Sistema:Ativo,Inativo
        public string TotalAtendimentosRealizados { get; set; } //Total de atendimentos realizados
                                                                //Este item é um contador que inicia em zero. Sempre que um médico realiza um atendimento este valor deve ser incrementado




        //public int PacienteId { get; set; }//O sistema deve perguntar qual foi o médico e paciente que participaram do atendimento. O atendimento médico deve ter o Identificador do paciente.

        //public int MedicoId { get; set; }

       




    }
}
