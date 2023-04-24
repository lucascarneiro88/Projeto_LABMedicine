﻿

using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class MedicoGetDto
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CadastroCrm { get; set; }
        public string Especializacao { get; set; }
        public EstadoSistemaEnum EstadoSistemaEnum { get; set; }  
        public string TotalAtendimentosRealizados { get; set; }
    }
}
