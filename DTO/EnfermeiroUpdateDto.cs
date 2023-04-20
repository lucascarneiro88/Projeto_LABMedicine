using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTO
{
    public class EnfermeiroUpdateDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CadastroCOFEN { get; set; }
    }    
}
