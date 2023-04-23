using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public class EstadoSistemaEnum
    {
        public int Ativo = 0;
        public int Inativo = 1;
       

    }
}
