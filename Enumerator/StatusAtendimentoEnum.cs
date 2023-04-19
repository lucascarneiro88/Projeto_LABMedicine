using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]//para converter o enum
    public static class StatusAtendimentoEnum
      
     
    {
        public const int AguardandoAtendimento = 0;
        public const int EmAtendimento = 1;
        public const int Atendido = 2;
        public const int NaoAtendido = 3;

        
    }

}
