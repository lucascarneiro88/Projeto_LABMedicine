using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class AtendimentoDto
    {
        
        
        public class MedicoDto
        {
            public int IdMedico { get; set; }//ver se precisa ser obrigatorio
            public int Id { get; set; }
            public int TotalAtendimentosRealizados { get; set; }
            public string Descricao { get; set; }
        }


        public class PacienteDto
        {
            public int IdPaciente { get; set; }//ver se precisa ser obrigatorio
            public int Id { get; set; }
            public int TotalAtendimentos { get; set; }
            public StatusAtendimentoEnum StatusAtendimento { get; set; }
            public string Descricao { get; set; }

        }
    }
}
