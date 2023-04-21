using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public  class EspecializacaoMedicoEnum
    {
        public int ClinicoGeral = 0 ;
        public int Anestesista = 1;
        public int Dermatologia = 2;
        public int Ginecologia = 3;
        public int Neurologia = 4;
        public int Pediatria = 5;
        public int Psiquiatria = 6;
        public int Ortopedia = 7;

    }
}
