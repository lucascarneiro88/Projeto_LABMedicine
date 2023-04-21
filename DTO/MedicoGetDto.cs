namespace LABMedicine.DTO
{
    public class MedicoGetDto
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CadastroCrm { get; set; }
        public string Especializacao { get; set; }//Especialização Clínica: Obrigatório com as seguintes opções
                                                  //Clínico Geral,Anestesista,Dermatologia,Ginecologia,Neurologia,Pediatria,Psiquiatria,Ortopedia
        public bool EstadoSistema { get; set; }  
        public string TotalAtendimentosRealizados { get; set; }
    }
}
