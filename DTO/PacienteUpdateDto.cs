namespace LABMedicine.DTO
{
    public class PacienteUpdateDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string ContatoDeEmergencia { get; set; }
        public string? Convenio { get; set; }
        public string StatusAtendimento { get; set; }
        public string? Alergias { get; set; }//Lista de Alergias
        public string? CuidadosEspecificos { get; set; }//Lista de Cuidados Específicos

        //public int TotalAtendimentos { get; set; }

    }
}
