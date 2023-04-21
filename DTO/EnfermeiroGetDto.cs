using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTO
{
    public class EnfermeiroGetDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string InstituicaoEnsinoFormacao { get; set; }
        public string CadastroCOFEN { get; set; }
    }
}
