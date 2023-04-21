using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]//para converter o enum
    public  class StatusAtendimentoEnum
      
     
    {
        public  int AguardandoAtendimento = 0;
        public  int EmAtendimento = 1;
        public  int Atendido = 2;
        public  int NaoAtendido = 3;

        
    }

}
