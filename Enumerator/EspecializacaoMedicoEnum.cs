using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public  enum EspecializacaoMedicoEnum
    {
         ClinicoGeral = 0 ,
        Anestesista = 1,
         Dermatologia = 2,
        Ginecologia = 3,
        Neurologia = 4,
        Pediatria = 5,
        Psiquiatria = 6,
        Ortopedia = 7

    }
}
